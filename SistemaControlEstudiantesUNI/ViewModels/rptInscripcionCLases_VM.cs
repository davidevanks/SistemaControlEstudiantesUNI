using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class rptInscripcionCLases_VM
    {
        //,,,,	
        //												
        public int  idEstudiante { get; set; }
        public string no_carnet { get; set; }
        public string Carreara { get; set; }

        public string Turno { get; set; }
        public string PlanEstudio { get; set; }
        public string NombreApellido { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string no_cedula { get; set; }
        public int edad { get; set; }
        public string direccion_habitual { get; set; }
        public string email { get; set; }
        public string celular { get; set; }

        public string fechaIngreso { get; set; }
        public string nombreAsignatura { get; set; }
        public string horario { get; set; }
        public string Docente { get; set; }
        public string Periodo { get; set; }

    }
}