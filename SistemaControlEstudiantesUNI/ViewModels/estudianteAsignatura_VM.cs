using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class estudianteAsignatura_VM
    {
        public long idEstudianteAsignatura { get; set; }
        public long id_estudiante { get; set; }
        public long id_asignatura { get; set; }
        public long id_docente { get; set; }
        public string horario { get; set; }
        public long id_periodo { get; set; }
        public double parcial_uno { get; set; }
        public double parcial_dos { get; set; }
        public double convocatoria { get; set; }
        public double nota_final { get; set; }
        public bool activo { get; set; }
        public string fecha_inscripcion { get; set; }
        public bool aprobado { get; set; }
        public bool completado { get; set; }


    }
}