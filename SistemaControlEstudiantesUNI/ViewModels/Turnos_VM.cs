using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class Turnos_VM
    {
        public long id { get; set; }
        [Required(ErrorMessage ="Campo Requerido")]
        [Display(Name ="Turno")]
        public string nombre_turno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Horario")]
        public string horario_turno { get; set; }
        public bool activo { get; set; }


    }
}