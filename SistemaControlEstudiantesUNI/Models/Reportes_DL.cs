using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class Reportes_DL
    {

        #region Reporte de Constancia de Notas
        public List<ListaConstanciaNotas> GetListaEstudiantesConsNotas()
        {
            List<ListaConstanciaNotas> lstEstudiante = new List<ListaConstanciaNotas>();

            try
            {

                using (var contexto=new ControlAlumnosEntities())
                {
                    lstEstudiante = contexto.GetListaConstanciaNotas().Select(x => new ListaConstanciaNotas
                    {
                        id=x.idEstudiante,
                        Estudiante=x.Estudiante

                    }).ToList();

                    return lstEstudiante;
                }
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                throw;
            }

        }

        public rptConstanciaNotasIndividual_VM GetListaEstudiantesNotasDetalle(int idEstudiante)
        {
            rptConstanciaNotasIndividual_VM lstEstudianteDetalles = new rptConstanciaNotasIndividual_VM();

            try
            {

                using (var contexto = new ControlAlumnosEntities())
                {
                    lstEstudianteDetalles = contexto.GetListaConstanciaNotasDetalleEstudiante(idEstudiante).Select(x => new rptConstanciaNotasIndividual_VM
                    {
                        id = x.idEstudiante,
                        Estudiante = x.Estudiante,
                        no_carnet=x.no_carnet,
                        Carrera=x.Carrera,
                        AnioCursa=x.AnioCursa,
                        fechaLetra=x.fechaLetra

                    }).FirstOrDefault();

                    return lstEstudianteDetalles;
                }
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                throw;
            }

        }


        public List<ConstanciaNotasPeriodos> GetListaConstanciaNotasPeriodos(int idEstudiante)
        {
            List<ConstanciaNotasPeriodos> lstPeriodos = new List<ConstanciaNotasPeriodos>();

            try
            {

                using (var contexto = new ControlAlumnosEntities())
                {
                    lstPeriodos = contexto.GetListaConstanciaNotasPeriodos(idEstudiante).Select(x => new ConstanciaNotasPeriodos
                    {
                      id=x.idPeriodo,
                      Periodo=x.Periodo

                    }).ToList();

                    return lstPeriodos;
                }
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                throw;
            }

        }


        public List<ConstanciaNotasAsignaturas> GetListaConstanciaNotasAsignaturas(int idEstudiante)
        {
            List<ConstanciaNotasAsignaturas> lstPeriodos = new List<ConstanciaNotasAsignaturas>();

            try
            {

                using (var contexto = new ControlAlumnosEntities())
                {
                    lstPeriodos = contexto.GetListaConstanciaNotasAsignaturas(idEstudiante).Select(x => new ConstanciaNotasAsignaturas
                    {
                        id=x.idEstudiante,
                        idPeriodo =x.idPeriodo,
                        Asignatura =x.Asignatura,
                        Notas =x.Notas,
                        Conv =x.Conv,
                        NotaLetras =x.NotaLetras,
                        ConvLetras =x.ConvLetras

                     }).ToList();

                    return lstPeriodos;
                }
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                throw;
            }

        }

        #endregion

        #region Reporte certificado final notas
        public List<ConstanciaNotasAsignaturas> GetListaCertificadoFinalNotasAsignaturas(int idEstudiante)
        {
            List<ConstanciaNotasAsignaturas> lstPeriodos = new List<ConstanciaNotasAsignaturas>();

            try
            {

                using (var contexto = new ControlAlumnosEntities())
                {
                    lstPeriodos = contexto.GetListaCertificadoFinalNotasAsignaturas(idEstudiante).Select(x => new ConstanciaNotasAsignaturas
                    {
                        id = x.idEstudiante,
                        idPeriodo = x.idPeriodo,
                        Asignatura = x.Asignatura,
                        Notas = x.Notas,
                        NotaLetras = x.NotaLetras

                    }).ToList();

                    return lstPeriodos;
                }
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                throw;
            }

        }
        #endregion

        #region ReporteHojaMatricula
        public List<estudiante> ListarEstudiantes()
        {
            List<estudiante> lstEstudiantes = new List<estudiante>();

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    //lstEstudiantes = contexto.estudiante.Where(x => x.activo == true).Select(x => new estudiante
                    //{
                    //    idEstudiante=x.idEstudiante,
                    //    nombres=x.nombres
                    //}).ToList();
                    lstEstudiantes = (from a in contexto.estudiante where a.activo == true && a.id_periodo != 10005 && a.anioPeriodo!=0 select a).ToList();


                }
                return lstEstudiantes;
            }
            catch (Exception ex)
            {
                return lstEstudiantes;
                throw;
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
                    activo = (bool)y.activo,
                    id_periodo = y.idPeriodo,
                    nombrePeriodo = y.nombre_periodo


                }).FirstOrDefault();

                return lstEstudiantes;
            }

        }
        #endregion


        #region Reporte constancia Individual
        public rptConstanciaIndividual_VM GetRptConstanciaIndividual(int idEstudiante)
        {

            rptConstanciaIndividual_VM lstRptConstanciaIndividual = new rptConstanciaIndividual_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstRptConstanciaIndividual = contexto.rptConstanciaAlumnoIndividual(idEstudiante).Select(x => new rptConstanciaIndividual_VM
                {
                    idEstudiante = (int)x.idEstudiante,
                    no_carnet = x.no_carnet,
                    Carrera = x.Carrera,
                    Turno = x.Turno,
                    NombreApellido = x.NombreApellido,
                    AnioCursa = x.AnioCursa,
                    Horario = x.Horario,
                    FechaLetras=x.fechaLetra
                }).ToList().FirstOrDefault();

                return lstRptConstanciaIndividual;
            }
        }
        #endregion


        #region Reporte inscripción clase
        public rptInscripcionCLases_VM GetRptInscripciónClase(int idEstudiante)
        {

            rptInscripcionCLases_VM DatosInscripcion = new rptInscripcionCLases_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                DatosInscripcion = contexto.reporteInscripcionClases(idEstudiante).Select(x => new rptInscripcionCLases_VM
                {
                  idEstudiante=(int)x.idEstudiante,
                  NombreApellido=x.nombreAsignatura,
                  no_carnet=x.no_carnet,
                  Carreara=x.Carreara,
                  Turno=x.Turno,
                  PlanEstudio=x.PlanEstudio,
                  EstadoCivil=x.EstadoCivil,
                  Sexo=x.Sexo,
                  no_cedula=x.no_cedula,
                  edad=(int)x.edad,
                  direccion_habitual=x.direccion_habitual,
                  email=x.email,
                  celular=x.celular,
                  telefono=x.telefono,
                  fechaIngreso=(DateTime)x.fecha_ingreso,
                  Periodo=x.Periodo

                }).ToList().FirstOrDefault();

                return DatosInscripcion;
            }
        }


        public List<rptListaAsignaturas> GetDetalleRptInscripciónClase(int idEstudiante)
        {

            List<rptListaAsignaturas> DetalleDatosInscripcion = new List<rptListaAsignaturas>();

            using (var contexto = new ControlAlumnosEntities())
            {
                DetalleDatosInscripcion = contexto.reporteInscripcionClases(idEstudiante).Select(x => new rptListaAsignaturas
                {
                         nombreAsignatura =x.nombreAsignatura,
                         horario=x.horario, 
                         Docente =x.Docente

                }).ToList();

                return DetalleDatosInscripcion;
            }
        }



        public List<estudiante> ListarEstudiantesInscripcion()
        {
            List<estudiante> lstEstudiantes = new List<estudiante>();

           

            using (var contexto = new ControlAlumnosEntities())
            {
                lstEstudiantes = contexto.GetListadoEstudiantesInscripcion().Select(x => new estudiante
                {
                   idEstudiante=x.idEstudiante,
                   nombres=x.NombreApellido

                }).ToList();

                return lstEstudiantes;
            }

        }
        #endregion
    }
}