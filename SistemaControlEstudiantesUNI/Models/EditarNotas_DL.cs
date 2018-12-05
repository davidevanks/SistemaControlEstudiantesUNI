using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;


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
                    
                }).Distinct().ToList();

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

    }
}