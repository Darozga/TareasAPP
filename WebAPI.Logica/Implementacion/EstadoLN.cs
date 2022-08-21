using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Interfaz;
using WebAPI.Logica.Interfaz;
using WebAPI.Model.Modelos;

namespace WebAPI.Logica.Implementacion
{
    /// <summary>        
    /// Logica para administrar los estados de las tareas      
    /// </summary>
    public class EstadoLN : IEstadoLN
    {
        private readonly IEstadoAD _estado;

        public EstadoLN(IEstadoAD estado)
        {
            _estado = estado;
        }

        /// <summary>        
        /// Metodo para obtner todos los estados      
        /// </summary>
        public Respuesta<IEnumerable<ModelEstado>> ObtenerEstados()
        {
            Respuesta<IEnumerable<ModelEstado>> objRespuesta = new Respuesta<IEnumerable<ModelEstado>>();
            try
            {
                objRespuesta = _estado.ObtenerEstados();
                objRespuesta.Exito();
            }
            catch (Exception ex)
            {
                objRespuesta.Error(ex);
            }
            return objRespuesta;
        }
    }
}
