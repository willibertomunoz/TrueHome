using VO = Bussiness.Models;
using System.Collections.Generic;
using Bussiness.Models;

namespace Bussiness.Manager
{
    public interface IPropertyManager
    {
        string AgregarPropiedad(Property Property);
        string ActualizarPropiedad(int id, Property date);
        string BorrarPropiedad(int id);
        bool ExistePropiedad(int id);
        List<VO.Property> ListaPropertiedades();
    }
}
