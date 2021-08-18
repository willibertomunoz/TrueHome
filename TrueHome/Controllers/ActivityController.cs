using Bussiness.Manager;
using Bussiness.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrueHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityManager _activityManager;
        public ActivityController(IActivityManager activityManager)
        {
            _activityManager = activityManager;
        }


        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _activityManager.ListaActividades();
        }


        [HttpPost]
        public string Post([FromBody] Activity value)
        {
            return _activityManager.AgregarActividad(value);
        }

        [HttpPut("{id}")]
        public string Reagendar(int id, [FromBody] DateTime fecha)
        {
            return _activityManager.ReagendarActividad(id, fecha);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _activityManager.CancelarActividad(id);
        }
    }
}
