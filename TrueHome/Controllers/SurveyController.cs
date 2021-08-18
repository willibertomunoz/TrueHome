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
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyManager _SurveyManager;
        public SurveyController(ISurveyManager SurveyManager)
        {
            _SurveyManager = SurveyManager;
        }


        [HttpGet]
        public IEnumerable<Survey> Get()
        {
            return _SurveyManager.ListaActividades();
        }


        [HttpPost]
        public void Post([FromBody] Survey value)
        {
            _SurveyManager.AgregarActividad(value);
        }

        [HttpPut("{id}")]
        public void Reagendar(int id, [FromBody] DateTime fecha)
        {
            _SurveyManager.ReagendarActividad(id, fecha);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _SurveyManager.CancelarActividad(id);
        }
    }
}
