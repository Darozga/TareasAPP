using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Modelos;

namespace WebAPI.Logica.Interfaz
{
    public interface IColaboradorLN
    {
        Respuesta<IEnumerable<ModelColaborador>> ObtenerColaboradores();
    }
}
