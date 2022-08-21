using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Interfaz.Models
{
    /// <summary>        
    /// Clase Tarea Model, se utiliza para crear la vista de tarea    
    /// </summary>
    public class TareaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Colaborador { get; set; }

        [Display(Name = "Colaborador")]
        public int? Colaborador_Id { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Estado")]
        public int? Estado_Id { get; set; }

        public string Prioridad { get; set; }

        [Display(Name = "Prioridad")]
        public int? Prioridad_Id { get; set; }


        [Required(ErrorMessage = "El campo Fecha Inicio es requerido")]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Inicio { get; set; }


        [Required(ErrorMessage = "El campo Fecha Fin es requerido")]
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Fin { get; set; }

        public string Notas { get; set; }
    }
}