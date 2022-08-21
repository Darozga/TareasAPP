using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Modelos;

namespace WebAPI.Data.Interfaz
{
    public interface IColaboradorAD
    {
        Respuesta<IEnumerable<ModelColaborador>> ObtenerColaboradores();

    }
}
