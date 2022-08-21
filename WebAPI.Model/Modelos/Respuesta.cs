using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model.Utilitarios;

namespace WebAPI.Model.Modelos
{
    /// <summary>        
    /// Modelo Respuesta, lo que se va ha enviar a la interfaz       
    /// </summary>
    public partial class Respuesta<T>
    {
        public bool Success { get; set; } 
        public byte enuTipoMensaje { get; set; }

        public string strMensajeRespuesta { get; set; }
        
        public T ValorRetorno { get; set; }

        public void Error(Exception ex) {
            Success = false; 
            enuTipoMensaje = (byte)EnumTipoMensaje.eTipoMensaje.Error;
            strMensajeRespuesta = ex.Message;
        }

        public void Exito() {
            Success = true;
            enuTipoMensaje = (byte)EnumTipoMensaje.eTipoMensaje.Satisfactorio;
            strMensajeRespuesta = Constantes.mensajeRespuesta.strMensajeExitoso;
        }
    }

    /// <summary>        
    /// Clase para saber el típo de mensaje que se va ha enviar a la interfaz      
    /// </summary>
    public class EnumTipoMensaje
    {
        public enum eTipoMensaje
        {
            Satisfactorio = 1,
            Informativo = 2,
            Validacion = 3,
            Error = 4

        }
    }
}
