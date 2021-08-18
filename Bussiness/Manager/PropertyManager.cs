using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Bussiness.Models;
using Bussiness.Enum;

namespace Bussiness.Manager
{
    public class PropertyManager:IPropertyManager
    {
        private readonly IAppContext _context;

        public PropertyManager(IAppContext appContext)
        {
            _context = appContext;
        }

        public string ActualizarPropiedad(int id, Property property)
        {
            var propiedad = _context.Property.Find(id);

            if(propiedad is not null)
            {
                property.UpdatedAt = DateTime.Now;
                _context.Property.Update(property.ToPO());
                return "Actualizada";
            }
            return "No se encontro la propiedad";
        }

        public string AgregarPropiedad(Property Property)
        {
            _context.Property.Add(Property.ToPO());
            return "Actualizada";
        }

        public string BorrarPropiedad(int id)
        {
            var propiedad = _context.Property.Find(id);

            if (propiedad is not null)
            {
                propiedad.UpdatedAt = DateTime.Now;
                propiedad.DisabledAt = DateTime.Now;
                propiedad.Status = Status.Cancelado.ToString();

                _context.Property.Update(propiedad);
                return "Borrado";
            }
            return "No se encontro propiedad";
        }

        public bool ExistePropiedad(int id)
        {
            var propiedad = _context.Property.Find(id);

            return propiedad is not null;
        }

        public List<Property> ListaPropertiedades()
        {
            List<Property> list = new();
            var prop = from p in _context.Property 
                      where (p.Status == Status.Vigente.ToString())
                      select p;

            foreach (var item in prop)
            {
                list.Add(new Property() {
                    Id = item.Id,
                    Status = item.Status,
                    DisabledAt = item.DisabledAt,
                    UpdatedAt = item.UpdatedAt,
                    CreatedAt = item.CreatedAt,
                    Description = item.Description,
                    Address = item.Address
                });
            }

            return list;
        }
    }
}
