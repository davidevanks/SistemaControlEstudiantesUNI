using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class Docentes_DL
    {

        public List<Docentes_VM> ListarDocentes()
        {
            List<Docentes_VM> lstDoc = new List<Docentes_VM>();

            using (var contexto = new ControlAlumnosEntities())
            {
                var result = (from y in contexto.docentes
                          join x in contexto.catalogos on y.id_categoria_academica equals x.id
                         
                          select new Docentes_VM { 
                              id=y.idDocentes,
                              id_categoria_academica=y.id_categoria_academica,
                              Nombre_rango_academico=x.Nombre,
                              nombre=y.nombre,
                              apellidos=y.apellidos,
                              no_cedula=y.no_cedula,
                              activo=(bool)y.activo
                          });

                lstDoc = result.ToList();

                return lstDoc;
            }


        }

        public Docentes_VM ListarDocentesId(int id)
        {
            Docentes_VM lstDoc = new Docentes_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                var result = (from y in contexto.docentes
                              join x in contexto.catalogos on y.id_categoria_academica equals x.id
                              where  y.idDocentes==id
                              select new Docentes_VM
                              {
                                  id = y.idDocentes,
                                  id_categoria_academica = y.id_categoria_academica,
                                  Nombre_rango_academico = x.Nombre,
                                  nombre = y.nombre,
                                  apellidos = y.apellidos,
                                  no_cedula=y.no_cedula,
                                  activo = (bool)y.activo
                              });

                lstDoc = result.FirstOrDefault();

                return lstDoc;
            }


        }


        public bool EditarDocente(AgregarDocentes_VM doc)
        {

            try
            {
                var Docente = new docentes { idDocentes = doc.id };

                using (var context = new ControlAlumnosEntities())

                {

                    context.docentes.Attach(Docente);

                    Docente.id_categoria_academica = doc.id_categoria_academica;
                    Docente.nombre = doc.nombre;
                    Docente.apellidos = doc.apellidos;
                    Docente.no_cedula = doc.no_cedula;
                    Docente.activo = doc.activo;

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


        public List<Catalogos_VM> ListarCatalogoId(int id)
        {

            List<Catalogos_VM> lstCat = new List<Catalogos_VM>();
            using (var contexto = new ControlAlumnosEntities())
            {
                //lstCat = contexto.catalogos.Where(x=>x.activo==true).ToList();
                //return lstCat;

                lstCat = contexto.catalogos.Where(x => x.activo == true && x.idPadre == id).Select(y => new Catalogos_VM
                {
                    id = y.id,
                    idPadre = (long)y.idPadre,
                    Nombre = y.Nombre,
                    activo = (bool)y.activo


                }).ToList();

                return lstCat;

            }


        }


   

        public bool GuardarDocente(AgregarDocentes_VM doc)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    docentes docente = new docentes();

                    docente.id_categoria_academica = doc.id_categoria_academica;
                    docente.nombre = doc.nombre;
                    docente.apellidos = doc.apellidos;
                    docente.no_cedula = doc.no_cedula;
                    docente.activo = true;

                  

                    contexto.docentes.Add(docente);
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


        public AgregarDocentes_VM ListarDocentesEditarId(int id)
        {
            AgregarDocentes_VM lstDoc = new AgregarDocentes_VM();

            using (var contexto = new ControlAlumnosEntities())
            {
                var result = (from y in contexto.docentes
                              join x in contexto.catalogos on y.id_categoria_academica equals x.id
                              where  y.idDocentes == id
                              select new AgregarDocentes_VM
                              {
                                  id = y.idDocentes,
                                  id_categoria_academica = (long)y.id_categoria_academica,
                                 
                                  nombre = y.nombre,
                                  apellidos = y.apellidos,
                                  no_cedula = y.no_cedula,
                                  activo = (bool)y.activo
                              });

                lstDoc = result.FirstOrDefault();

                return lstDoc;
            }


        }



    }
}