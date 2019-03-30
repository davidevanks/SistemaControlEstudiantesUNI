//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaControlEstudiantesUNI
{
    using System;
    using System.Collections.Generic;
    
    public partial class estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estudiante()
        {
            this.estudianteGrupo = new HashSet<estudianteGrupo>();
            this.estudianteNotas = new HashSet<estudianteNotas>();
        }
    
        public long idEstudiante { get; set; }
        public long id_carrera { get; set; }
        public long id_turno { get; set; }
        public long id_plan_estudio { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string no_carnet { get; set; }
        public Nullable<long> id_estado_civil { get; set; }
        public Nullable<long> id_sexo { get; set; }
        public string lugar_nacimiento { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public Nullable<long> id_departamento { get; set; }
        public string no_cedula { get; set; }
        public Nullable<int> edad { get; set; }
        public string direccion_habitual { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public Nullable<bool> trabaja { get; set; }
        public string centro_trabajo { get; set; }
        public string telefono_trabajo { get; set; }
        public string cargo_trabajo { get; set; }
        public Nullable<System.DateTime> fecha_grabacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public Nullable<long> id_municipio { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public Nullable<long> id_periodo { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<int> id_anio_cursa { get; set; }
    
        public virtual turnos turnos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estudianteGrupo> estudianteGrupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estudianteNotas> estudianteNotas { get; set; }
    }
}
