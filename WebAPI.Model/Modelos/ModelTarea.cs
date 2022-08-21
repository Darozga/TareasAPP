using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Model.Modelos
{
    /// <summary>        
    /// Modelo Tarea      
    /// </summary>
    public class ModelTarea
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string? Colaborador { get; set; }

        public int? Colaborador_Id { get; set; }

        public string? Estado  { get; set; }

        public int Estado_Id { get; set; }

        public string? Prioridad { get; set; }

        public int Prioridad_Id { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Fin { get; set; }

        public string? Notas { get; set; }

    }
}
