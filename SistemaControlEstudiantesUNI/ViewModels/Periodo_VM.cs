using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class Periodo_VM
    {
        public long id { get; set; }
        [Required(ErrorMessage ="Campor Requerido")]
        [Display(Name ="Periodo")]
        public string nombre_periodo { get; set; }
        public bool activo { get; set; }


    }
}