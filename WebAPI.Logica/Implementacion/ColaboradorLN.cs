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
    /// Logica para administrar los colaboradores      
    /// </summary>
    public class ColaboradorLN : IColaboradorLN
    {
        private readonly IColaboradorAD _colaborador;

        public ColaboradorLN(IColaboradorAD colaborador)
        {
            _colaborador = colaborador;
        }

        /// <summary>        
        /// Metodo para obtener todos los colaboradores        
        /// </summary>
        public Respuesta<IEnumerable<ModelColaborador>> ObtenerColaboradores()
        {
            Respuesta<IEnumerable<ModelColaborador>> objRespuesta = new Respuesta<IEnumerable<ModelColaborador>>();  
            try
            {
                objRespuesta = _colaborador.ObtenerColaboradores();
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
