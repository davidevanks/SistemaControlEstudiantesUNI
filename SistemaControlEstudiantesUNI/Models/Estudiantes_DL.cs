using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{

    public class Estudiantes_DL
    {

        public List<EstudianteSimple> ListarEstudiante()
        {

            using (var contexto = new ControlAlumnosEntities())
            {
                List<EstudianteSimple> lstEstudiantes = new List<EstudianteSimple>();

                lstEstudiantes = contexto.ListarEstudiantes(0).Select(y => new EstudianteSimple
                {
                    id=y.idEs,
                    nombres=y.nombres,
                    apellidos=y.apellidos,
                    direccion_habitual=y.direccion_habitual,
                    fecha_nacimiento=(DateTime)y.fecha_nacimiento,
                    edad=(int)y.edad,
                    celular=y.celular,
                    centro_trabajo=y.centro_trabajo,
                    email=y.email,
                    lugar_nacimiento=y.lugar_nacimiento,
                    trabaja=(bool)y.trabaja,
                    no_carnet=y.no_carnet,
                    no_cedula=y.no_cedula,
                    telefono=y.telefono,
                    telefono_trabajo=y.telefono_trabajo,
                    fecha_grabacion=(DateTime)y.fecha_grabacion,
                    fecha_ingreso=(DateTime)y.fecha_ingreso,
                    fecha_modificacion=(DateTime)y.fecha_modificacion,
                    id_carrera=y.id_carrera,
                    Carrera=y.Carrera,
                    id_departamento=(long)y.id_departamento,
                    Departamento=y.Departamento,
                    id_municipio=(long)y.id_municipio,
                    Municipio=y.Municipio,
                    id_estado_civil=(long)y.id_estado_civil,
                    estadoCivil=y.estadoCivil,
                    id_plan_estudio=y.id_plan_estudio,
                    planEstudio=y.planEstudio,
                    id_sexo=(long)y.id_sexo,
                    Sexo=y.Sexo,
                    id_turno=y.id_turno,
                    Turno=y.Turno,
                    activo=(bool)y.activo


                }).ToList();

                return lstEstudiantes;
            }

        }



    }
}