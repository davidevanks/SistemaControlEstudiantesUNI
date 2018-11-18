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
                   // fecha_modificacion=(DateTime)y.fecha_modificacion,
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

        public EstudianteSimple ListarEstudianteDetailsId(int id)
        {

            using (var contexto = new ControlAlumnosEntities())
            {
                EstudianteSimple lstEstudiantes = new EstudianteSimple();

                lstEstudiantes = contexto.ListarEstudiantes(id).Select(y => new EstudianteSimple
                {
                    id = y.idEs,
                    nombres = y.nombres,
                    apellidos = y.apellidos,
                    direccion_habitual = y.direccion_habitual,
                    fecha_nacimiento = (DateTime)y.fecha_nacimiento,
                    edad = (int)y.edad,
                    celular = y.celular,
                    centro_trabajo = y.centro_trabajo,
                    email = y.email,
                    lugar_nacimiento = y.lugar_nacimiento,
                    trabaja = (bool)y.trabaja,
                    no_carnet = y.no_carnet,
                    no_cedula = y.no_cedula,
                    telefono = y.telefono,
                    telefono_trabajo = y.telefono_trabajo,
                    fecha_grabacion = (DateTime)y.fecha_grabacion,
                    fecha_ingreso = (DateTime)y.fecha_ingreso,
                    // fecha_modificacion=(DateTime)y.fecha_modificacion,
                    id_carrera = y.id_carrera,
                    Carrera = y.Carrera,
                    id_departamento = (long)y.id_departamento,
                    Departamento = y.Departamento,
                    id_municipio = (long)y.id_municipio,
                    Municipio = y.Municipio,
                    id_estado_civil = (long)y.id_estado_civil,
                    estadoCivil = y.estadoCivil,
                    id_plan_estudio = y.id_plan_estudio,
                    planEstudio = y.planEstudio,
                    id_sexo = (long)y.id_sexo,
                    Sexo = y.Sexo,
                    id_turno = y.id_turno,
                    Turno = y.Turno,
                    activo = (bool)y.activo


                }).FirstOrDefault();

                return lstEstudiantes;
            }

        }

        //Metodos para catalogos de la tabla estudiantes
        public List<Catalogos_VM> lstCatalogos(int id)
        {

            List<Catalogos_VM> lstCatalogos = new List<Catalogos_VM>();

            using (var contexto= new ControlAlumnosEntities())
            {


                lstCatalogos = contexto.catalogos.Where(x => x.activo == true && x.idPadre == id).Select(y => new Catalogos_VM
                {
                    id = y.id,
                    idPadre = (long)y.idPadre,
                    Nombre = y.Nombre,
                    activo = (bool)y.activo


                }).ToList();

                return lstCatalogos;

            }


        }



        public List<localidad> lstDepartamentos()
        {

            List<localidad> lstDepartamentos = new List<localidad>();

            using (var contexto = new ControlAlumnosEntities())
            {


                //lstDepartamentos = contexto.localidad.Where(x => x.activo == true).Select(y => new localidad
                //{
                //   idLocalidad=y.idLocalidad,
                //   id_padre=y.id_padre,
                //   Nombre=y.Nombre,
                //   activo=y.activo


                //}).ToList();

                lstDepartamentos = (from y in contexto.localidad where y.activo == true select y).ToList();

                return lstDepartamentos;

            }


        }




        public List<localidad> lstMunicipio(int idPadre)
        {

            List<localidad> lstMunicipios = new List<localidad>();

            using (var contexto = new ControlAlumnosEntities())
            {


                //lstMunicipios = contexto.localidad.Where(x => x.activo == true &&x.id_padre==idPadre).Select(y => new localidad
                //{
                //    idLocalidad = y.idLocalidad,
                //    id_padre = y.id_padre,
                //    Nombre = y.Nombre,
                //    activo = y.activo


                //}).ToList();

                lstMunicipios= (from y in contexto.localidad where y.activo == true && y.id_padre==idPadre select y).ToList();

                return lstMunicipios;

            }


        }




        public List<turnos> lstTurnos()
        {

            List<turnos> lstTurnos = new List<turnos>();

            using (var contexto = new ControlAlumnosEntities())
            {


                //lstMunicipios = contexto.turnos.Where(x => x.activo == true ).Select(y => new turnos
                //{
                //  idTurno=y.idTurno,
                //  nombre_turno=y.nombre_turno,
                //  horario_turno=y.horario_turno,
                //  activo=y.activo


                //}).ToList();



                lstTurnos = (from y in contexto.turnos where y.activo == true  select y).ToList();

                return lstTurnos;

            }


        }
        //


        public bool GuardarEstudiante(AgregarEstudiante estudiantes)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    estudiante est = new estudiante();

                    est.nombres = estudiantes.nombres;
                    est.apellidos = estudiantes.apellidos;
                    est.cargo_trabajo = estudiantes.cargo_trabajo;
                    est.celular = estudiantes.celular;
                    est.centro_trabajo = estudiantes.centro_trabajo;
                    est.direccion_habitual = estudiantes.direccion_habitual;
                    est.edad = estudiantes.edad;
                    est.email = estudiantes.email;
                    est.fecha_grabacion = DateTime.Now;
                    est.fecha_ingreso = Convert.ToDateTime(estudiantes.fecha_ingreso);
                    est.fecha_nacimiento = Convert.ToDateTime(estudiantes.fecha_nacimiento);
                    est.id_carrera = estudiantes.id_carrera;
                    est.id_departamento = estudiantes.id_departamento;
                    est.id_estado_civil = estudiantes.id_estado_civil;
                    est.id_municipio = estudiantes.id_municipio;
                    est.id_plan_estudio = estudiantes.id_plan_estudio;
                    est.id_sexo = estudiantes.id_sexo;
                    est.id_turno = estudiantes.id_turno;
                    est.trabaja = estudiantes.trabaja;
                    est.no_carnet = estudiantes.no_carnet;
                    est.no_cedula = estudiantes.no_cedula;
                    est.lugar_nacimiento = estudiantes.lugar_nacimiento;
                    est.telefono = estudiantes.telefono;
                    est.telefono_trabajo = estudiantes.telefono_trabajo;
                    est.activo = true;


                    contexto.estudiante.Add(est);
                    contexto.SaveChanges();


                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }

        public AgregarEstudiante ListarEstudianteId(int id)
        {

            using (var contexto = new ControlAlumnosEntities())
            {
                AgregarEstudiante lstEstudiantes = new AgregarEstudiante();

                lstEstudiantes = contexto.ListarEstudiantes(0).Where(y=>y.idEs==id).Select(y => new AgregarEstudiante
                {
                    id = y.idEs,
                    nombres = y.nombres,
                    apellidos = y.apellidos,
                    direccion_habitual = y.direccion_habitual,
                    fecha_nacimiento = Convert.ToDateTime(y.fecha_nacimiento).ToShortDateString(),
                    edad = (int)y.edad,
                    celular = y.celular,
                    centro_trabajo = y.centro_trabajo,
                    email = y.email,
                    lugar_nacimiento = y.lugar_nacimiento,
                    trabaja = (bool)y.trabaja,
                    no_carnet = y.no_carnet,
                    no_cedula = y.no_cedula,
                    telefono = y.telefono,
                    cargo_trabajo=y.cargo_trabajo,
                    telefono_trabajo = y.telefono_trabajo,
                    fecha_grabacion = (DateTime)y.fecha_grabacion,
                    fecha_ingreso = Convert.ToDateTime(y.fecha_ingreso).ToShortDateString(),
                    // fecha_modificacion=(DateTime)y.fecha_modificacion,
                    id_carrera = y.id_carrera,
                    //Carrera = y.Carrera,
                    id_departamento = (long)y.id_departamento,
                    //Departamento = y.Departamento,
                    id_municipio = (long)y.id_municipio,
                    //Municipio = y.Municipio,
                    id_estado_civil = (long)y.id_estado_civil,
                    //estadoCivil = y.estadoCivil,
                    id_plan_estudio = y.id_plan_estudio,
                    //planEstudio = y.planEstudio,
                    id_sexo = (long)y.id_sexo,
                    //Sexo = y.Sexo,
                    id_turno = y.id_turno,
                    //Turno = y.Turno,
                    activo = (bool)y.activo


                }).FirstOrDefault();

                return lstEstudiantes;
            }

        }



        public bool EditarEstudiante(AgregarEstudiante est)
        {

            try
            {
                var estudiantes = new estudiante { idEstudiante = est.id };
              

                using (var context = new ControlAlumnosEntities())

                {

                    context.estudiante.Attach(estudiantes);


                    estudiantes.nombres = est.nombres;
                    estudiantes.apellidos = est.apellidos;
                    estudiantes.direccion_habitual = est.direccion_habitual;
                    estudiantes.fecha_nacimiento = Convert.ToDateTime(est.fecha_nacimiento);
                    estudiantes.edad = (int)est.edad;
                    estudiantes.celular = est.celular;
                    estudiantes.centro_trabajo = est.centro_trabajo;
                    estudiantes.email = est.email;
                    estudiantes.lugar_nacimiento = est.lugar_nacimiento;
                    estudiantes.trabaja = (bool)est.trabaja;
                    estudiantes.no_carnet = est.no_carnet;
                    estudiantes.no_cedula = est.no_cedula;
                    estudiantes.telefono = est.telefono;
                    estudiantes.cargo_trabajo = est.cargo_trabajo;
                    estudiantes.telefono_trabajo = est.telefono_trabajo;
                    //estudiantes.fecha_grabacion = est.fecha_grabacion;
                    estudiantes.fecha_ingreso = Convert.ToDateTime(est.fecha_ingreso);
                    estudiantes.fecha_modificacion = est.fecha_modificacion;
                    estudiantes.id_carrera = est.id_carrera;
                    //Carrera = y.Carrera,
                    estudiantes.id_departamento = (long)est.id_departamento;
                    //Departamento = y.Departamento,
                    estudiantes.id_municipio = (long)est.id_municipio;
                    //Municipio = y.Municipio,
                    estudiantes.id_estado_civil = (long)est.id_estado_civil;
                    //estadoCivil = y.estadoCivil,
                    estudiantes.id_plan_estudio = est.id_plan_estudio;
                    //planEstudio = y.planEstudio,
                    estudiantes.id_sexo = (long)est.id_sexo;
                    //Sexo = y.Sexo,
                    estudiantes.id_turno = est.id_turno;
                    //Turno = y.Turno,
                    estudiantes.activo = (bool)est.activo;

                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }



        }


    }
}