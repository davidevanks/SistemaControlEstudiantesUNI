using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class rptConstanciaIndividual_DL
    {
        public List<rptConstanciaIndividual_VM> GetRptConstanciaIndividual(int idEstudiante)
        {

            List<rptConstanciaIndividual_VM> lstRptConstanciaIndividual = new List<rptConstanciaIndividual_VM>();

            using (var contexto= new ControlAlumnosEntities())
            {
                lstRptConstanciaIndividual = contexto.rptConstanciaAlumnoIndividual(idEstudiante).Select(x => new rptConstanciaIndividual_VM
                {
                    idEstudiante=(int)x.idEstudiante,
                    no_carnet=x.no_carnet,
                    Carrera=x.Carrera,
                    Turno=x.Turno,
                    NombreApellido=x.NombreApellido,
                    AnioCursa=x.AnioCursa,
                    Horario=x.Horario
                }).ToList();

                return lstRptConstanciaIndividual;
            }
        }

    }
}