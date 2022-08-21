using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Interfaz.Models
{
    /// <summary>        
    /// Clase Filter Model, utilizada para filtrar las tareas     
    /// </summary>
    public class FilterModel
    {
        public int? Colaborador { get; set; }

        public int? Estado { get; set; }

        public int? Prioridad { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }




    }
}