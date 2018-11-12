using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class Asignaturas_DL
    {
        public List<AsignaturaSimple_VM> ListarAsignaturas()
        {

            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();

            using (var contexto= new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.ListarAsignaturas(0).Select(x => new AsignaturaSimple_VM
                {
                    id=x.asignaturaId,
                    codigoAsignatura=x.codigoAsignatura,
                    asignatura=x.asignatura,
                    asignaturaRequisitoId=x.asignaturaRequisitoId,
                    codigoAsignaturaRequisito=x.codigoAsignaturaRequisito,
                    asignaturasRequisito=x.asignaturaRequisito,
                    activo=(bool)x.activoAsignatura

                }).ToList();

                return lstAsignaturas;

            }


        }

        public List<AsignaturaSimple_VM> ListarAsignaturasDetalle(long id)
        {

            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.ListarAsignaturas(id).Select(x => new AsignaturaSimple_VM
                {
                    id = x.asignaturaId,
                    codigoAsignatura = x.codigoAsignatura,
                    asignatura = x.asignatura,
                    asignaturaRequisitoId = x.asignaturaRequisitoId,
                    codigoAsignaturaRequisito = x.codigoAsignaturaRequisito,
                    asignaturasRequisito = x.asignaturaRequisito,
                    activo = (bool)x.activoAsignatura

                }).ToList();

                return lstAsignaturas;

            }


        }

        public Asignaturas_VM ListarAsignaturasEditarId(int id)
        {

            Asignaturas_VM lstAsignaturas = new Asignaturas_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.ListarAsignaturas(id).Select(x => new Asignaturas_VM
                {
                    id = x.asignaturaId,
                    codigoAsignaturas = x.codigoAsignatura,
                    asignaturas = x.asignatura,
                    asignaturaRequisitosId = x.asignaturaRequisitoId,

                    activo = (bool)x.activoAsignatura

                }).FirstOrDefault() ;

                return lstAsignaturas;

            }


        }


        public List<AsignaturaSimple_VM> ListarAsignaturasRequisitos()
        {

            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.ListarAsignaturas(-1).Select(x => new AsignaturaSimple_VM
                {
                    id = x.asignaturaId,
                    //codigoAsignatura = x.codigoAsignatura,
                    asignatura = x.asignatura,
                    //asignaturaRequisitoId = x.asignaturaRequisitoId,
                    //codigoAsignaturaRequisito = x.codigoAsignaturaRequisito,
                    //asignaturasRequisitos = x.asignaturaRequisito,
                    //activo = (bool)x.activoAsignatura

                }).ToList();


        
                return lstAsignaturas;

            }


        }


        public List<AsignaturaSimple_VM> ListarAsignaturasRequisitosEditar()
        {

            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                lstAsignaturas = contexto.ListarAsignaturas(0).Select(x => new AsignaturaSimple_VM
                {
                    id = x.asignaturaId,
                    //codigoAsignatura = x.codigoAsignatura,
                    asignatura = x.asignatura,
                    

                }).ToList();



                return lstAsignaturas;

            }


        }

        public bool guardarAsignatura(Asignaturas_VM asignatura)
        {
            try
            {
                using (var contexto=new ControlAlumnosEntities())
                {
                    asignaturas asig = new asignaturas();

                    asig.nombreAsignatura = asignatura.asignaturas;
                    asig.codigoAsignatura = asignatura.codigoAsignaturas;
                    asig.idPadre = asignatura.asignaturaRequisitosId;
                    asig.activo = true;

                    contexto.asignaturas.Add(asig);
                    contexto.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


            
        }


        public bool EditarAsignatura(Asignaturas_VM asig)
        {

            try
            {
                var asignatura = new asignaturas { idAsignatura = asig.id };

                using (var context = new ControlAlumnosEntities())

                {

                    context.asignaturas.Attach(asignatura);

                    asignatura.idAsignatura = asig.id;
                    asignatura.nombreAsignatura = asig.asignaturas;
                    asignatura.codigoAsignatura = asig.codigoAsignaturas;
                    asignatura.idPadre = asig.asignaturaRequisitosId;
                    asignatura.activo = asig.activo;
                    
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