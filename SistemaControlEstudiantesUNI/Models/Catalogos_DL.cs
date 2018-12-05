using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SistemaControlEstudiantesUNI.ViewModels;
using System.Data.Entity;


namespace SistemaControlEstudiantesUNI.Models
{
    
    public class Catalogos_DL
    {
        #region Listar
        /// <summary>
        /// /Metodos para mostrar información
        /// </summary>
        /// <returns></returns>
        public List<Catalogos_VM> ListarCatalogos()
        {
            List<Catalogos_VM> lstCat = new List<Catalogos_VM>();
            using(var contexto = new ControlAlumnosEntities())
            {
                //lstCat = contexto.catalogos.Where(x=>x.activo==true).ToList();
                //return lstCat;

                lstCat = contexto.catalogos.Where(x =>  x.idPadre==0).Select(y => new Catalogos_VM
                {
                    id=y.id,
                    idPadre=(long)y.idPadre,
                    Nombre=y.Nombre,
                    activo = (bool)y.activo,


                }).ToList();

                return lstCat;

            }

        }



        public List<Catalogos_VM> ListarCatalogosHijos(Int32 idPadre)
        {
            List<Catalogos_VM> lstCat = new List<Catalogos_VM>();
            using (var contexto = new ControlAlumnosEntities())
            {
                //lstCat = contexto.catalogos.Where(x=>x.activo==true).ToList();
                //return lstCat;

                lstCat = contexto.catalogos.Where(x =>  x.idPadre == idPadre).Select(y => new Catalogos_VM
                {
                    id = y.id,
                    idPadre = (long)y.idPadre,
                    Nombre = y.Nombre,
                    activo = (bool)y.activo,


                }).ToList();

                return lstCat;

            }

        }


        public Catalogos_VM ListarCatalogoId(int id)
        {

            Catalogos_VM lstCat = new Catalogos_VM();
            using (var contexto = new ControlAlumnosEntities())
            {
                //lstCat = contexto.catalogos.Where(x=>x.activo==true).ToList();
                //return lstCat;

                lstCat = contexto.catalogos.Where(x =>  x.id==id).Select(y => new Catalogos_VM
                {
                    id = y.id,
                    idPadre = (long)y.idPadre,
                    Nombre = y.Nombre,
                    activo = (bool)y.activo


                }).FirstOrDefault();

                return lstCat;

            }


        }

        #endregion




        public bool BorrarCatalogo(Catalogos_VM cat)
        {
            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    catalogos catalogo = new catalogos();

                    catalogo.id = cat.id;
                    catalogo.idPadre = cat.idPadre;
                    catalogo.Nombre = cat.Nombre;
                    catalogo.activo = false;

                    contexto.Entry(catalogo).State = EntityState.Modified;

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


        public bool GuardarCatalogo(Catalogos_VM cat)
        {
            
            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    catalogos catalogo = new catalogos();

                    catalogo.idPadre = 0;
                    catalogo.Nombre = cat.Nombre;
                    catalogo.activo = true;

                    contexto.catalogos.Add(catalogo);
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


        public bool GuardarCatalogoHijo(Catalogos_VM cat)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    catalogos catalogo = new catalogos();

                    catalogo.idPadre = cat.idPadre;
                    catalogo.Nombre = cat.Nombre;
                    catalogo.activo = true;

                    contexto.catalogos.Add(catalogo);
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

        public bool EditarCatalogo(Catalogos_VM cat)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    catalogos catalogo = new catalogos();

                    catalogo.id = cat.id;
                    catalogo.idPadre = cat.idPadre;
                    catalogo.Nombre = cat.Nombre;
                    catalogo.activo = cat.activo;

                    contexto.Entry(catalogo).State = EntityState.Modified;
                    
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


        public bool EditarCatalogoHijo(Catalogos_VM cat)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    catalogos catalogo = new catalogos();

                    catalogo.id = cat.id;
                    catalogo.idPadre = cat.idPadre;
                    catalogo.Nombre = cat.Nombre;
                    catalogo.activo = cat.activo;

                    contexto.Entry(catalogo).State = EntityState.Modified;

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

    }
}