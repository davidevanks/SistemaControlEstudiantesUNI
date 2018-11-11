using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class Periodo_DL
    {
        public List<Periodo_VM> ListarPeriodos()
        {
            List<Periodo_VM> lstPeriodos = new List<Periodo_VM>();
            using (var contexto= new ControlAlumnosEntities())
            {
                   lstPeriodos = contexto.periodo.Select(x=> new Periodo_VM {

                       id =x.idPeriodo,
                        nombre_periodo=x.nombre_periodo,
                       activo=(bool)x.activo

                      }).ToList();

                return lstPeriodos;
            }


        }


        public Periodo_VM ListarPeriodosId(long id)
        {
            Periodo_VM lstPeriodos = new Periodo_VM();
            using (var contexto = new ControlAlumnosEntities())
            {
                lstPeriodos = contexto.periodo.Where(x =>  x.idPeriodo==id).Select(x => new Periodo_VM
                {

                    id = x.idPeriodo,
                    nombre_periodo = x.nombre_periodo,
                    activo = (bool)x.activo

                }).FirstOrDefault();

                return lstPeriodos;
            }


        }

        public bool EditarPeriodo(Periodo_VM periodoId)
        {

            try
            {
                var Pe = new periodo { idPeriodo = periodoId.id };

                using (var context = new ControlAlumnosEntities())

                {

                    context.periodo.Attach(Pe);
                    Pe.idPeriodo = periodoId.id;
                    Pe.nombre_periodo = periodoId.nombre_periodo;
                    Pe.activo = periodoId.activo;
                    

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


        public bool GuardarPeriodo(Periodo_VM per)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    periodo periodos = new periodo();

                    periodos.nombre_periodo = per.nombre_periodo;
                    periodos.activo = true;



                    contexto.periodo.Add(periodos);
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


    }
}