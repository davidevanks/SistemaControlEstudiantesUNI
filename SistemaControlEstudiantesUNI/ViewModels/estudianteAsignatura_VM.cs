using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class estudianteAsignaturaSimple_VM
    {
        public long id { get; set; }
        public long idEstudianteAsignatura { get; set; }
        public long id_periodo { get; set; }
        public string Periodo { get; set; }
        [Display(Name ="Nombres")]
        public string nombres { get; set; }
        [Display(Name ="Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Display(Name = "Celular")]
        public string celular { get; set; }
        [Display(Name = "Centro de Trabajo")]
        public string centro_trabajo { get; set; }
        [Display(Name = "Dirección Habitual")]
        public string direccion_habitual { get; set; }
        [Display(Name = "Cargo de trabajo")]
        public string cargo_trabajo { get; set; }
        [Display(Name ="Email")]
        public string email { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string lugar_nacimiento { get; set; }
        public bool trabaja { get; set; }
        [Display(Name = "No Carnet")]
        public string no_carnet { get; set; }
        [Display(Name = "No Cédula")]
        public string no_cedula { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Telefono Trabajo")]
        public string telefono_trabajo { get; set; }
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Estado Civil")]
        public string estadoCivil { get; set; }
        [Display(Name = "Municipio")]
        public string Municipio { get; set; }
        [Display(Name = "Plan de Estudio")]
        public string planEstudio { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Turno")]
        public string Turno { get; set; }
        public long id_asignatura { get; set; }
        public long idPadreAsig { get; set; }
        [Display(Name = "Asignatura")]
        public string nombreAsignatura { get; set; }
        [Display(Name = "Horario")]
        public string horario { get; set; }
        public long id_docente { get; set; }
        [Display(Name = "Docente")]
        public string Docente { get; set; }
        public bool activo { get; set; }

    }

    public class AgregarEstudianteAsignatura_VM
    {
        public long id { get; set; }
        public long idEstudianteAsignatura { get; set; }
        public long id_grupo { get; set; }
        public string Grupo { get; set; }
        public long id_periodo { get; set; }
        public string Periodo { get; set; }
        [Display(Name = "Nombres")]
        public string nombres { get; set; }
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Display(Name = "Celular")]
        public string celular { get; set; }
        [Display(Name = "Centro de Trabajo")]
        public string centro_trabajo { get; set; }
        [Display(Name = "Dirección Habitual")]
        public string direccion_habitual { get; set; }
        [Display(Name = "Cargo de trabajo")]
        public string cargo_trabajo { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string lugar_nacimiento { get; set; }
        public bool trabaja { get; set; }
        [Display(Name = "No Carnet")]
        public string no_carnet { get; set; }
        [Display(Name = "No Cédula")]
        public string no_cedula { get; set; }
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Display(Name = "Telefono Trabajo")]
        public string telefono_trabajo { get; set; }
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
        [Display(Name = "Estado Civil")]
        public string estadoCivil { get; set; }
        [Display(Name = "Municipio")]
        public string Municipio { get; set; }
        [Display(Name = "Plan de Estudio")]
        public string planEstudio { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Turno")]
        public string Turno { get; set; }
        public long id_asignatura { get; set; }
        public long idPadreAsig { get; set; }
        [Display(Name = "Asignatura")]
        public List<asignaturas> nombreAsignatura { get; set; }
        [Display(Name = "Horario")]
        public string horario { get; set; }
        public long id_docente { get; set; }
        [Display(Name = "Docente")]
        public List<docentes> Docente { get; set; }

        public List<HijosEstudianteAsignatura> lstHijosEsAsig { get; set; }
        public bool activo { get; set; }

    }

    public class HijosEstudianteAsignatura
    {
        
        public long id_estudiante { get; set; }
        public long id_docente { get; set; }
        public long id_grupo { get; set; }
        public long id_asignatura { get; set; }
        public long idPadre { get; set; }
        public long idPeriodo { get; set; }
        public long idEstudianteAsignatura { get; set; }
        public string Asignatura { get; set; }
        public string Docente { get; set; }
        public string horario { get; set; }

        public string Grupo { get; set; }
        //campos para agregar notas de los estudiantes y aprobar / completar clases
        public float parcial_uno { get; set; }
        public float parcial_dos { get; set; }
        public float convocatoria { get; set; }
        public float nota_final { get; set; }

        public bool aprobado { get; set; }
        public bool completado { get; set; }

    }


    public class AgregarHijosEstudianteAsignatura
    {

        public long id_estudiante { get; set; }
        public long id_docente { get; set; }
        public long id_asignatura { get; set; }
        public long idEstudianteAsignatura { get; set; }
        public long id_grupo { get; set; }
        public long idPadre { get; set; }
        public long id_periodo { get; set; }
        public List<asignaturas> Asignatura { get; set; }
        public List<docentes> Docente { get; set; }
        public string horario { get; set; }
        public List<catalogos> Grupo { get; set; }


    }

}