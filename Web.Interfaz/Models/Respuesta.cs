using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Interfaz.Models
{
    /// <summary>        
    /// Modelo Respuesta, utilizada para obtener la respuesta del api      
    /// </summary>
    public partial class Respuesta<T>
    {
        public bool Success { get; set; }
        public byte enuTipoMensaje { get; set; }

        public string strMensajeRespuesta { get; set; }

        public T ValorRetorno { get; set; }
    }
}