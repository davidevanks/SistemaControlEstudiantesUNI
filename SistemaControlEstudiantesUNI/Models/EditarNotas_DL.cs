using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;
using MoreLinq;


namespace SistemaControlEstudiantesUNI.Models
{
    public class EditarNotas_DL
    {
        public List<DocentesNotas_VM> ListarDocentes()
        {
            List<DocentesNotas_VM> lstDoc = new List<DocentesNotas_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstDoc = contexto.ListarDataNotas().Select(x => new DocentesNotas_VM
                {
                    id=(long)x.id_docente,
                    nombre=x.Docente
                }).Distinct().ToList();

                return lstDoc;
            }

        }


        public List<GrupoNotas_VM> ListarGrupos(int idDocente)
        {
            List<GrupoNotas_VM> lstGr = new List<GrupoNotas_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstGr = contexto.ListarDataNotas().Where(x=>x.id_docente==idDocente).Select(x => new GrupoNotas_VM
                {
                   id=x.idGrupo,
                   Grupo=x.Grupo
                }).Distinct().ToList();

                return lstGr;
            }

        }


        public List<AsignaturaNotas_VM> ListarAsignatura(int idDocente,int idGrupo)
        {
            List<AsignaturaNotas_VM> lstAsig = new List<AsignaturaNotas_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsig = contexto.ListarDataNotas().Where(x => x.id_docente == idDocente && x.idGrupo==idGrupo).Select(x => new AsignaturaNotas_VM
                {
                    id=(long)x.id_asignatura,
                    Asignatura=x.Asignatura
                    
                }).DistinctBy(p=>p.id).ToList();

                return lstAsig;
            }

        }


        public List<EstudianteNotas_VM> ListarEstudiante(int idDocente, int idGrupo,int idAsignatura)
        {
            List<EstudianteNotas_VM> lstEstudiante = new List<EstudianteNotas_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstEstudiante = contexto.ListarDataNotas().Where(x => x.id_docente == idDocente && x.idGrupo == idGrupo && x.id_asignatura==idAsignatura).Select(x => new EstudianteNotas_VM
                {
                    id=(long)x.id_estudiante,
                    Estudiante=x.Estudiante,
                    idEstudianteAsignatura=x.idEstudianteAsignatura
                }).ToList();

                return lstEstudiante;
            }

        }

        //metodos para editar / guardar las notas de clases una vez evaluados los estudiantes
        public bool EditarNotas(HijosEstudianteAsignatura NotasEstudiantes)
        {

            try
            {
                var Notas = new estudianteAsignatura { idEstudianteAsignatura = NotasEstudiantes.idEstudianteAsignatura };

                using (var context = new ControlAlumnosEntities())

                {

                    context.estudianteAsignatura.Attach(Notas);

                    Notas.parcial_uno = NotasEstudiantes.parcial_uno;
                    Notas.parcial_dos = NotasEstudiantes.parcial_dos;
                    Notas.convocatoria = NotasEstudiantes.convocatoria;
                    Notas.nota_final = NotasEstudiantes.nota_final;
                    Notas.aprobado = NotasEstudiantes.aprobado;
                    Notas.completado = NotasEstudiantes.completado;

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



        public HijosEstudianteAsignatura ListarNota(Int64 idEstudianteAsignatura)
        {

            HijosEstudianteAsignatura ListaNotaO = new HijosEstudianteAsignatura();

            using (var contexto = new ControlAlumnosEntities())
            {
                ListaNotaO = contexto.ListarEstudianteAsignaturaXid(idEstudianteAsignatura).Select(x => new HijosEstudianteAsignatura
                {
                    idEstudianteAsignatura=x.idEstudianteAsignatura,
                    parcial_uno=(float)x.parcial_uno.GetValueOrDefault()  ,
                    parcial_dos=(float)x.parcial_dos.GetValueOrDefault(),
                    nota_final =(float)x.nota_final.GetValueOrDefault(),
                    convocatoria =(float)x.convocatoria.GetValueOrDefault(),
                    completado =(bool)x.completado.GetValueOrDefault(),
                    aprobado =(bool)x.aprobado.GetValueOrDefault()



                }).FirstOrDefault();

                return ListaNotaO;
            }

        }
        //

    }
}