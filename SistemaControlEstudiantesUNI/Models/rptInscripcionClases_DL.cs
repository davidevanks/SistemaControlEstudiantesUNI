using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class rptInscripcionClases_DL
    {

        public List<rptInscripcionCLases_VM> leerRptInscripcionClases()
        {

            List<rptInscripcionCLases_VM> lstInscripcionClases = new List<rptInscripcionCLases_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstInscripcionClases = contexto.rptInscripcionClases().Select(x => new rptInscripcionCLases_VM
                {
                    idEstudiante = (int)x.idEstudiante,

                    no_carnet = x.no_carnet,
                    Carreara = x.Carreara,
                    Turno = x.Turno,

                    PlanEstudio = x.PlanEstudio,
                    NombreApellido = x.NombreApellido,
                    EstadoCivil = x.EstadoCivil,
                    Sexo = x.Sexo,
                    no_cedula = x.no_cedula,
                    edad = (int)x.edad,
                    direccion_habitual = x.direccion_habitual,
                    email = x.email,
                    celular = x.celular,

                    fechaIngreso = x.fecha_ingreso.ToString(),
                    nombreAsignatura = x.nombreAsignatura,
                    horario = x.horario,
                    Docente = x.Docente,
                    Periodo = x.Periodo


                }).ToList();
            }


            return lstInscripcionClases;
        }


    }
}