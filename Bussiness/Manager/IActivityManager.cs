using VO = Bussiness.Models;
using System;
using System.Collections.Generic;
using Bussiness.Models;

namespace Bussiness.Manager
{
    public interface IActivityManager
    {
        string AgregarActividad(Activity activity);
        string ReagendarActividad(int id, DateTime date);
        string CancelarActividad(int id);
        List<VO.Activity> ListaActividades();
    }
}
