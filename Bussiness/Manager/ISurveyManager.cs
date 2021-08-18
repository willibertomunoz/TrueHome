using VO = Bussiness.Models;
using System;
using System.Collections.Generic;
using Bussiness.Models;

namespace Bussiness.Manager
{
    public interface ISurveyManager
    {
        bool AgregarActividad(Survey Survey);
        bool ReagendarActividad(int id, DateTime date);
        bool CancelarActividad(int id);
        List<VO.Survey> ListaActividades();
    }
}
