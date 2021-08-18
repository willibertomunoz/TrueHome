using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Models;
using Bussiness.Enum;

namespace Bussiness.Manager
{
    public class ActivityManager : IActivityManager
    {
        private readonly IAppContext _context;
        private readonly IPropertyManager _propertyManager;

        public ActivityManager(IAppContext appContext, IPropertyManager propertyManager)
        {
            _context = appContext;
            _propertyManager = propertyManager;
        }

        public string AgregarActividad(Activity activity)
        {
            if (activity?.PropertyId != 0 && _propertyManager.ExistePropiedad(activity.PropertyId))
            {

                var act = from a in _context.Activity
                          join p in _context.Property on a.PropertyId equals p.Id
                          where (a.CreatedAt >= activity.CreatedAt && a.CreatedAt <= activity.CreatedAt)
                          || (p.Status != Status.Vigente.ToString())
                          select a;
                if (act.ToList().Count == 0)
                {
                    _context.Activity.Add(activity.ToPO());
                    return "Actividad Agregada";
                }
                return "No cumple los requisitos";
            }
            return "No existe la propieda";
        }

        public string CancelarActividad(int id)
        {
            var actividad = _context.Activity.Find(id);

            if (actividad != null && actividad.Status != Status.Cancelado.ToString())
            {
                actividad.Status = Status.Cancelado.ToString();

                _context.Activity.Update(actividad);

                return "Actividad cancelada";
            }
            return "No se puede cancelar";
        }

        public List<Activity> ListaActividades()
        {
            var listActividades = new List<Activity>();
            var actividades = from a in _context.Activity
                              where (a.Schedule >= DateTime.Now.AddDays(-3) && a.Schedule <= DateTime.Now.AddDays(14))
                              select a;

            foreach (var act in actividades)
            {
                listActividades.Add(new Activity()
                {
                    Id = act.Id,
                    PropertyId = act.PropertyId,
                    Schedule = act.Schedule,
                    Title = act.Title,
                    CreatedAt = act.CreatedAt,
                    UpdatedAt = act.UpdatedAt,
                    Condicion = ObtenerCondicion(act.Status, act.Schedule)
                });
            }

            return listActividades;
        }

        public string ReagendarActividad(int id, DateTime date)
        {
            var actividad = _context.Activity.Find(id);

            if (actividad != null && actividad.Status != Status.Cancelado.ToString())
            {
                actividad.Schedule = date;

                _context.Activity.Update(actividad);

                return "Actividad agendada";
            }

            return "Actividad no agendada ";
        }

        private string ObtenerCondicion(string status, DateTime fechaRealizar)
        {
            if (fechaRealizar > DateTime.Now && status == Status.Vigente.ToString())
            {
                return Status.PendienteARealizar.ToString();
            }
            else if (fechaRealizar < DateTime.Now && status == Status.Vigente.ToString())
            {
                return Status.Atrasada.ToString();
            }
            return Status.Realizada.ToString();
        }
    }
}
