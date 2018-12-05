using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{



    public class DocentesNotas_VM
    {
        public long id { get; set; }

        [Display(Name = "Docentes")]
        public string nombre { get; set; }
    }

    public class AsignaturaNotas_VM
    {
        public long id { get; set; }

        [Display(Name = "Asignaturas")]
        public string Asignatura { get; set; }
    }

    public class GrupoNotas_VM
    {
        public long id { get; set; }

        [Display(Name = "Grupos")]
        public string Grupo { get; set; }
    }

    public class EstudianteNotas_VM
    {

        public long id { get; set; }
        public string Estudiante { get; set; }
        public long idEstudianteAsignatura { get; set; }
    }


    public class EstudianteEditarNotas_VM
    {
     

        public List<DocentesNotas_VM> docentes { get; set; }
        public List<GrupoNotas_VM> Grupos { get; set; }

        public List<AsignaturaNotas_VM> Asignaturas { get; set; }
        public List<EstudianteNotas_VM> estudiantes { get; set; }
    


    }

}