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
                lstEstAsig = contexto.ListarEstudianteAsignatura1(0).Select(x => new estudianteAsignaturaSimple_VM
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
                    Docente=x.Docente,
                    Asignatura=x.Asignatura,
                    horario=x.horario,
                    Grupo=x.Grupo

                }).ToList();

                return lstHijosEstudianteAsig;

            }


        }

        public AgregarEstudianteAsignatura_VM ListarEstudianteAsigEditar(int id)
        {
            AgregarEstudianteAsignatura_VM asig = new AgregarEstudianteAsignatura_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                asig = contexto.ListarEstudianteAsignatura1(id).Select(x => new AgregarEstudianteAsignatura_VM
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
                    activo = (bool)x.activo




                }).FirstOrDefault();

                return asig;
            }

        }



        //metodos para pantalla interna de asignaciones
        public List<docentes> lstDocente()
        {

            List<docentes> lstDoc = new List<docentes>();

            using (var contexto= new ControlAlumnosEntities())
            {
                lstDoc = contexto.docentes.Where(x => x.activo == true).Select(x => x).ToList();

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


                    contexto.estudianteAsignatura.Add(ae);
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

        //


    }
}