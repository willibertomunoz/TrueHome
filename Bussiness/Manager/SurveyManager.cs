using DataAccess;
using System;
using System.Collections.Generic;
using Bussiness.Models;

namespace Bussiness.Manager
{
    public class SurveyManager:ISurveyManager
    {
        private readonly IAppContext _context;

        public SurveyManager(IAppContext appContext)
        {
            _context = appContext;
        }

        public bool AgregarActividad(Survey Survey)
        {
            throw new NotImplementedException();
        }

        public bool CancelarActividad(int id)
        {
            throw new NotImplementedException();
        }

        public List<Survey> ListaActividades()
        {
            throw new NotImplementedException();
        }

        public bool ReagendarActividad(int id, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
