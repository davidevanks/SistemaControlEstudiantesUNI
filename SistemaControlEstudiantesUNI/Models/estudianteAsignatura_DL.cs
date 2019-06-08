using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class estudianteAsignatura_DL
    {

        public List<estudianteAsignaturaSimple_VM> ListarEstudiantesAsignatura()
        {
            List<estudianteAsignaturaSimple_VM> lstEstAsig = new List<estudianteAsignaturaSimple_VM>();

            using (var contexto= new ControlAlumnosEntities())
            {
                lstEstAsig = contexto.ListarEstudianteAsignatura(0).Select(x => new estudianteAsignaturaSimple_VM
                {
                    id = x.idEs,
                    //idEstudianteAsignatura=(long)x.idEstudianteAsignatura,
                    id_periodo=(long)x.idPeriodo,
                    Periodo=x.Periodo,
                    nombres=x.nombres,
                    apellidos=x.apellidos,
                    celular=x.celular,
                    direccion_habitual=x.direccion_habitual,
                    no_carnet=x.no_carnet,
                    no_cedula=x.no_cedula,
                    Carrera=x.Carrera,
                    planEstudio=x.planEstudio,
                    Sexo=x.Sexo,
                    Turno=x.Turno,
                    //id_asignatura=(long)x.id_asignatura,
                    //idPadreAsig=(long)x.idPadreAsig,
                    //nombreAsignatura=x.nombreAsignatura,
                    //horario=x.horario,
                    //id_docente=(long)x.id_docente,
                    //Docente=x.Docente,
                    activo=(bool)x.activo



                }).ToList();

                return lstEstAsig;
            }


        }

        public List<HijosEstudianteAsignatura> ListarHijosEstudianteAsig(int ides)
        {
            List<HijosEstudianteAsignatura> lstHijosEstudianteAsig = new List<HijosEstudianteAsignatura>();

            using (var contexto=new  ControlAlumnosEntities())
            {
                lstHijosEstudianteAsig = contexto.ListarHijosEstudianteAsig1(ides).Select(x => new HijosEstudianteAsignatura
                {
                    id_estudiante = (long)x.id_estudiante,
                    idEstudianteAsignatura=x.idEstudianteAsignatura,
                    idPadre=(long)x.idPadre,
                    id_asignatura=(long)x.id_asignatura,
                    id_docente=(long)x.id_docente,
                    Docente = x.Docente,
                    Asignatura = x.Asignatura,
                    horario =x.horario,
                    id_grupo=x.idGrupo,
                    Grupo = x.Grupo


                }).ToList();

                return lstHijosEstudianteAsig;

            }


        }

        public AgregarEstudianteAsignatura_VM ListarEstudianteAsigEditar(int id)
        {
            AgregarEstudianteAsignatura_VM asig = new AgregarEstudianteAsignatura_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                asig = contexto.ListarEstudianteAsignatura(id).Select(x => new AgregarEstudianteAsignatura_VM
                {
                    id = x.idEs,
                    //idEstudianteAsignatura = (long)x.idEstudianteAsignatura,
                    id_periodo = (long)x.idPeriodo,
                    Periodo= x.Periodo,
                    nombres = x.nombres,
                    apellidos = x.apellidos,
                    celular = x.celular,
                    direccion_habitual = x.direccion_habitual,
                    no_carnet = x.no_carnet,
                    no_cedula = x.no_cedula,
                    Carrera = x.Carrera,
                    planEstudio = x.planEstudio,
                    Sexo = x.Sexo,
                    Turno = x.Turno,
                    estadoCivil=x.estadoCivil,
                    //id_asignatura = (long)x.id_asignatura,
                    //idPadreAsig = (long)x.idPadreAsig,
                    //nombreAsignatura = x.nombreAsignatura,
                    //horario = x.horario,
                    //id_docente = (long)x.id_docente,
                    //Docente = x.Docente,
                    anioPeriodo=(int)x.anioPeriodo,
                    activo = (bool)x.activo




                }).FirstOrDefault();

                return asig;
            }

        }



        //metodos para pantalla interna de asignaciones
        public AgregarHijosEstudianteAsignatura ListarAsignarClasesEditar(int id)
        {
            AgregarHijosEstudianteAsignatura asig = new AgregarHijosEstudianteAsignatura();

            using (var contexto = new ControlAlumnosEntities())
            {
                asig = contexto.ListarHijosEstudianteAsig1(0).Where(x=>x.idEstudianteAsignatura==id).Select(x => new AgregarHijosEstudianteAsignatura
                {
                 id_asignatura=(long)x.id_asignatura,
                 idEstudianteAsignatura=x.idEstudianteAsignatura,
                 id_docente=(long)x.id_docente,
                 id_estudiante=(long)x.id_estudiante,
                 id_grupo=x.idGrupo,
                 horario=x.horario,
                 




                }).FirstOrDefault();

                return asig;
            }

        }


        public bool EditarHijos(AgregarHijosEstudianteAsignatura hijos)
        {

            try
            {
                var asignaturasEstudiantes = new estudianteAsignatura { idEstudianteAsignatura = hijos.idEstudianteAsignatura };

                using (var context = new ControlAlumnosEntities())

                {

                    context.estudianteAsignatura.Attach(asignaturasEstudiantes);

                    asignaturasEstudiantes.idEstudianteAsignatura = hijos.idEstudianteAsignatura;
                    asignaturasEstudiantes.id_asignatura = hijos.id_asignatura;
                    asignaturasEstudiantes.id_docente = hijos.id_docente;
                    asignaturasEstudiantes.id_estudiante = hijos.id_estudiante;
                    asignaturasEstudiantes.id_grupo = hijos.id_grupo;
                    asignaturasEstudiantes.id_periodo = hijos.id_periodo;
                    asignaturasEstudiantes.id_grupo = hijos.id_grupo;
                    asignaturasEstudiantes.horario = hijos.horario;

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


        public bool EliminarHijos(AgregarHijosEstudianteAsignatura hijos)
        {

            try
            {
                var asignaturasEstudiantes = new estudianteAsignatura { idEstudianteAsignatura = hijos.idEstudianteAsignatura };

                using (var context = new ControlAlumnosEntities())

                {

                    context.estudianteAsignatura.Attach(asignaturasEstudiantes);

                    asignaturasEstudiantes.idEstudianteAsignatura = hijos.idEstudianteAsignatura;
                    //asignaturasEstudiantes.id_asignatura = hijos.id_asignatura;
                    //asignaturasEstudiantes.id_docente = hijos.id_docente;
                    //asignaturasEstudiantes.id_estudiante = hijos.id_estudiante;
                    //asignaturasEstudiantes.id_grupo = hijos.id_grupo;
                    //asignaturasEstudiantes.id_periodo = hijos.id_periodo;
                    //asignaturasEstudiantes.id_grupo = hijos.id_grupo;
                    //asignaturasEstudiantes.horario = hijos.horario;
                    asignaturasEstudiantes.activo = false;

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

        public List<docentes> lstDocente()
        {

            List<docentes> lstDoc = new List<docentes>();

            using (var contexto= new ControlAlumnosEntities())
            {
                lstDoc = contexto.ListarDocentes().Select(x => new docentes {
                    idDocentes=x.idDocentes,
                    nombre=x.Docentes


                }).ToList();


                return lstDoc;
            }


        }

        public List<asignaturas> lstAsignaturas()
        {

            List<asignaturas> lstAsignaturas = new List<asignaturas>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.asignaturas.Where(x => x.activo == true &&x.idAsignatura!=8).Select(x => x).ToList();

                return lstAsignaturas;
            }


        }

        public List<catalogos> lstGrupos()
        {

            List<catalogos> lstGrupos = new List<catalogos>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstGrupos = contexto.catalogos.Where(x => x.activo == true && x.idPadre==22).Select(x => x).ToList();

                return lstGrupos;
            }


        }




        public bool GuardarAsignacionClase(AgregarHijosEstudianteAsignatura asig)
        {

            try
            {
                Int64 CantAsig = 0;
                var con = new ControlAlumnosEntities();
                CantAsig = con.estudianteAsignatura.Where(x => x.id_asignatura == asig.id_asignatura && x.id_estudiante == asig.id_estudiante && x.activo==true ).Select(x => x.idEstudianteAsignatura).FirstOrDefault();
                if(CantAsig==0)
                {
                    using (var contexto = new ControlAlumnosEntities())
                    {
                        estudianteAsignatura ae = new estudianteAsignatura();

                        ae.id_asignatura = asig.id_asignatura;
                        ae.id_docente = asig.id_docente;
                        ae.id_estudiante = asig.id_estudiante;
                        ae.id_grupo = asig.id_grupo;
                        ae.id_periodo = asig.id_periodo;
                        ae.activo = true;
                        ae.aprobado = false;
                        ae.completado = false;
                        ae.horario = asig.horario;
                        ae.fecha_inscripcion = DateTime.Now;
                        //se agrego periodoActual a 1
                        ae.periodoActual = true;
                        ae.anioPeriodo = asig.anioPeriodo;
                        contexto.estudianteAsignatura.Add(ae);
                        contexto.SaveChanges();


                        return true;
                    }
                }
                else
                {
                    return false;

                }
              
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }


        //validar asignatura dependiente

        public bool ValidarAsignatura(int idEst,int idAsig)
        {
            bool ban=false;
            int indicador;

            using (var contexto = new ControlAlumnosEntities())
            {
                indicador = (int)contexto.ValidarAsignatura(idAsig, idEst).FirstOrDefault();

                // si es 0, la clase no es permitida 
                if (indicador == 0)
                    ban = false;
                //si el resultado es diferente que 0, nos indica que la clase fue aprobada y completada y tiene derecho a seguir
                else if (indicador != 0)
                    ban = true;
                else if (indicador == 8)
                    ban = true;

            }
            return ban;

        }

        //


    }
}