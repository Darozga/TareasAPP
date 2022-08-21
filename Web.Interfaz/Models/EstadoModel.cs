using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Interfaz.Models
{
    /// <summary>        
    /// Clase Estado Model, utilizada para cargar los estados de las tareas   
    /// </summary>
    public class EstadoModel
    {
        public int Id { get; set; }
        public string Estado { get; set; }
    }
}