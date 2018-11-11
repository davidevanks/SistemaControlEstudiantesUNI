using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class Catalogos_VM
    {

        public long id { get; set; }
        public long idPadre { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        public string Nombre { get; set; }
        public bool activo { get; set; }


    }




}