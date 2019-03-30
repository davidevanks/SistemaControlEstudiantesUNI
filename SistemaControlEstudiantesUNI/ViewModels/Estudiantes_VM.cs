using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{


    public class EstudianteSimple
    {
        public long id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombres")]
        public string nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "Dirección habitual")]
        public string direccion_habitual { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime fecha_nacimiento { get; set; }
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No Celular")]
        public string celular { get; set; }
        [Display(Name = "Centro de trabajo")]
        public string centro_trabajo { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string lugar_nacimiento { get; set; }
        [Display(Name = "Trabaja?")]
        public bool trabaja { get; set; }
        [Display(Name = "No Carnet")]
        public string no_carnet { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "No Cédula")]
        public string no_cedula { get; set; }
        [Display(Name = "No Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "No Teléfono trabajo")]
        public string telefono_trabajo { get; set; }
        public System.DateTime fecha_grabacion { get; set; }
        [Display(Name = "Fecha Ingreso")]
        public System.DateTime fecha_ingreso { get; set; }
        public System.DateTime fecha_modificacion { get; set; }
        public long id_carrera { get; set; }
        public string Carrera { get; set; }
        public long id_departamento { get; set; }
        public string Departamento { get; set; }
        public long id_estado_civil { get; set; }
        [Display(Name = "Estado Civil")]
        public string estadoCivil { get; set; }
        public long id_municipio { get; set; }
        public string Municipio { get; set; }
        public long id_plan_estudio { get; set; }
        [Display(Name = "Plan de Estudio")]
        public string planEstudio { get; set; }
        public long id_sexo { get; set; }
        public string Sexo { get; set; }
        public long id_turno { get; set; }
        public string Turno { get; set; }

        public long  id_periodo { get; set; }
        public string nombrePeriodo { get; set; }
        public bool activo { get; set; }

    }


    public class AgregarEstudiante
    {
        public long id { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "Dirección habitual")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string direccion_habitual { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string fecha_nacimiento { get; set; }
        [Display(Name = "Edad")]
        [Range(14, 100, ErrorMessage = "Edad fuera de rango permitido")]
        public int edad { get; set; }
        [Display(Name = "No Celular")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string celular { get; set; }
        [Display(Name = "Centro de Trabajo")]
        public string centro_trabajo { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Lugar de Nacimiento")]
        public string lugar_nacimiento { get; set; }
        [Display(Name = "Trabaja?")]
        public bool trabaja { get; set; }
        [Display(Name = "No Carnet")]
        public string no_carnet { get; set; }
        [Display(Name = "No Cédula")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string no_cedula { get; set; }
        [Display(Name = "No Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "No Teléfono Trabajo")]
        public string telefono_trabajo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha_grabacion { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string fecha_ingreso { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fecha_modificacion { get; set; }
        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_carrera { get; set; }
        [Display(Name = "Carrera")]
      
        public List<Catalogos_VM> Carreras { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_departamento { get; set; }
        [Display(Name = "Departamento")]
        public List<localidad> Departamentos { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_municipio { get; set; }
        [Display(Name = "Municipio")]
        public List<localidad> Municipios { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_estado_civil { get; set; }
        [Display(Name = "Estado Civil")]
        public List<Catalogos_VM> estadoCiviles { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_plan_estudio { get; set; }
        [Display(Name = "Plan de Estudios")]
        public List<Catalogos_VM> planEstudios { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_sexo { get; set; }
        [Display(Name = "Sexo")]
        public List<Catalogos_VM> Sexos { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public long id_turno { get; set; }
        [Display(Name = "Turno")]
       
        public List<turnos> Turnos { get; set; }
        public List<Periodo_VM> periodos { get; set; }
        [Display(Name = "Cargo Trabajo")]
        public string cargo_trabajo { get; set; }
        public bool activo { get; set; }
    }


}