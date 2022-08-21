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
    /// Logica para administar la Prioridad de las tareas      
    /// </summary>
    public class PrioridadLN : IPrioridadLN
    {

        private readonly IPrioridadAD _prioridad;

        public PrioridadLN(IPrioridadAD prioridad)
        {
            _prioridad = prioridad;
        }

        /// <summary>        
        /// Metodo para obtener todas las prioridades      
        /// </summary>
        public Respuesta<IEnumerable<ModelPrioridad>> ObtenerPrioridades()
        {
            Respuesta<IEnumerable<ModelPrioridad>> objRespuesta = new Respuesta<IEnumerable<ModelPrioridad>>();
            try
            {
                objRespuesta = _prioridad.ObtenerPrioridades();
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
