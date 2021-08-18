using Bussiness.Manager;
using Bussiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace TrueHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _PropertyManager;
        public PropertyController(IPropertyManager PropertyManager)
        {
            _PropertyManager = PropertyManager;
        }


        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return _PropertyManager.ListaPropertiedades();
        }


        [HttpPost]
        public string Post([FromBody] Property value)
        {
            return _PropertyManager.AgregarPropiedad(value);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _PropertyManager.BorrarPropiedad(id);
        }
    }
}
