using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class rptConstanciaIndividual_VM
    {

        public int idEstudiante { get; set; }
        public string no_carnet { get; set; }
        public string Carrera { get; set; }
        public string Turno { get; set; }
        public string NombreApellido { get; set; }
        public string AnioCursa { get; set; }
        public string Horario { get; set; }
        public string FechaLetras { get; set; }
    }
}