using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;



namespace SistemaControlEstudiantesUNI.Controllers
{
    public class CatalogosController : BaseController
    {
        // GET: Catalogos
        Catalogos_DL dl = new Catalogos_DL();
       
        
        public ActionResult Index()
        {

            Session["idPadre"] = null;
            List<Catalogos_VM> lstCatalogos = new List<Catalogos_VM>();
            lstCatalogos = dl.ListarCatalogos();
            if (lstCatalogos.Count > 0)
            {
                return View(lstCatalogos);
            }
            else
            {
                //regresar vista persoanlizada de error, modificar luego
                return View(lstCatalogos);
            }
            
        }


 

        // GET: Catalogos/Details/5
        public ActionResult Details(int id)
        {
            Catalogos_VM cat = new Catalogos_VM();
            cat = dl.ListarCatalogoId(id);
            return View(cat);
        }

        // GET: Catalogos/Create
        public ActionResult Create()
        {

            return View();
        }


        // POST: Catalogos/Create
        [HttpPost]
        public ActionResult Create(Catalogos_VM catalogos)
        {
            try
            {

                if(ModelState.IsValid)
                {
                    if (dl.GuardarCatalogo(catalogos))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro Guardado",true);
                        return RedirectToAction("Index");
                    }

                    else
                    {
                        
                        // return View(catalogos);
                        
                    }
                   
                }
                // TODO: Add insert logic here
                Danger("Error al guardar registro",true);
                return View(catalogos);

            }
            catch(Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: "+ex.ToString(), true);
                return View(catalogos);
            }
        }

        // GET: Catalogos/Edit/5
        public ActionResult Edit(int id)
        {
            //Mandar a consultar datos
            Catalogos_VM cat = new Catalogos_VM();
            cat = dl.ListarCatalogoId(id);

            return View(cat);
        }

        // POST: Catalogos/Edit/5
        [HttpPost]
        public ActionResult Edit(Catalogos_VM catalogos)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarCatalogo(catalogos))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro actualizado!", true);
                        return RedirectToAction("Index");
                    }

                    else
                    {

                        // return View(catalogos);

                    }

                }
                // TODO: Add insert logic here
                Danger("Error al actualizar registro", true);
                return View(catalogos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(catalogos);
            }
        }

        // GET: Catalogos/Delete/5
        public ActionResult Delete(int id)
        {

            Catalogos_VM cat = new Catalogos_VM();
            cat = dl.ListarCatalogoId(id);
            return View(cat);
        }

        // POST: Catalogos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Catalogos_VM catalogo)
        {
            try
            {
                Catalogos_VM cat = new Catalogos_VM();
                cat = dl.ListarCatalogoId(id);
                // TODO: Add delete logic here
                if (dl.BorrarCatalogo(cat))
                {
                    Success("Registro eliminado!");
                    return RedirectToAction("Index");
                }
                else
                {
                    Danger("Error al eliminar registro",true);
                    return View(catalogo);
                }
                
            }
            catch(Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al eliminar registro: " + ex.ToString(), true);
                return View(catalogo);
            }
        }

        #region MetodosParaCategorias

        // GET: Catalogos/Edit/5
        public ActionResult EditHijo(int id)
        {
            //Mandar a consultar datos
            Catalogos_VM cat = new Catalogos_VM();
            cat = dl.ListarCatalogoId(id);

            return View(cat);
        }

        // POST: Catalogos/Edit/5
        [HttpPost]
        public ActionResult EditHijo(Catalogos_VM catalogos)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarCatalogoHijo(catalogos))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro actualizado!", true);
                        return RedirectToAction("ListarCatHijos", new { id = Convert.ToInt32(Session["idPadre"]) });
                    }

                    else
                    {

                        // return View(catalogos);

                    }

                }
                // TODO: Add insert logic here
                Danger("Error al actualizar registro", true);
                return View(catalogos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(catalogos);
            }
        }


        public ActionResult DetailsHijo(int id)
        {
            Catalogos_VM cat = new Catalogos_VM();
            cat = dl.ListarCatalogoId(id);
            return View(cat);
        }



        // GET: Catalogos/CreateHijo
        public ActionResult CreateHijo()
        {

            return View();
        }



        // POST: Catalogos/CreateHijo
        [HttpPost]
        public ActionResult CreateHijo(Catalogos_VM catalogos)
        {
            try
            {
                //asignar idpadre, para guardar
                catalogos.idPadre = Convert.ToInt32(Session["idPadre"]);
                if (ModelState.IsValid)
                {
                    if (dl.GuardarCatalogoHijo(catalogos))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro Guardado", true);
                        return RedirectToAction("ListarCatHijos", new { id = Convert.ToInt32(Session["idPadre"]) });
                    }

                    else
                    {

                        // return View(catalogos);

                    }

                }
                // TODO: Add insert logic here
                Danger("Error al guardar registro", true);
                return View(catalogos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(catalogos);
            }
        }

        public ActionResult ListarCatHijos(int id)
        {

            Session["idPadre"] = id;
            List<Catalogos_VM> lstCatalogos = new List<Catalogos_VM>();
            lstCatalogos = dl.ListarCatalogosHijos(id);
            return View(lstCatalogos);
        }
        #endregion 

    }
}
