using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class Asignaturas_VM
    {
        public long id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string codigoAsignaturas { get; set; }
        [Required(ErrorMessage ="Campo Requerido")]
        public string asignaturas { get; set; }
        [Display(Name = "Asignatura Requisito")]
        [Required(ErrorMessage = "Campo requerido")]
        public long asignaturaRequisitosId { get; set; }
        //public string codigoAsignaturaRequisito { get; set; }
        public List<AsignaturaSimple_VM> asignaturasRequisitos { get; set; }
        public bool activo { get; set; }




    }


    public class AsignaturaSimple_VM
    {

        public long? id { get; set; }
       [Display(Name ="Codigo")]
        public string codigoAsignatura { get; set; }
        [Display(Name = "Asignatura")]
        public  string asignatura { get; set; }
        public Nullable<long> asignaturaRequisitoId { get; set; }
        public string codigoAsignaturaRequisito { get; set; }
        [Display(Name = "Asignatura Requisito")]
        public string asignaturasRequisito { get; set; }
        public bool activo { get; set; }

    }
}