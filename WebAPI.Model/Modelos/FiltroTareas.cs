using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Model.Modelos
{

    /// <summary>        
    /// Clase para obtener los filtros enviados desde la interfaz       
    /// </summary>
    public class FiltroTareas
    {
        public int? Colaborador { get; set; }

        public int? Estado { get; set; }

        public int? Prioridad { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

    }
}
