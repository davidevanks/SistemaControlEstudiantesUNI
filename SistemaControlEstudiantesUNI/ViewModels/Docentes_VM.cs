using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class Docentes_VM
    {
        
        public long id { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Apellidos")]
        
        public string apellidos { get; set; }
        public Nullable<long> id_categoria_academica { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name ="Nivel Academico")]
        public string Nombre_rango_academico { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Cedúla")]
        public string no_cedula { get; set; }
        public bool activo { get; set; }


    }



    public class AgregarDocentes_VM
    {

        public long id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Apellidos")]

        public string apellidos { get; set; }
        [Display(Name = "Nivel Academico")]
        [Required(ErrorMessage = "Campo requerido")]
        public long id_categoria_academica { get; set; }

      
        [Display(Name = "Nivel Academico")]
        public List<Catalogos_VM> listaCat { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Cedúla")]
        public string no_cedula { get; set; }
        public bool activo { get; set; }


    }
}