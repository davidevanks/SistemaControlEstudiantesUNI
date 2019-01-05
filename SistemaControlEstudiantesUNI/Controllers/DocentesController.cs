using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;
using SistemaControlEstudiantesUNI.Controllers;

namespace SistemaControlEstudiantesUNI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DocentesController : BaseController
    {

        Docentes_DL dc = new Docentes_DL();
        // GET: Docentes
        public ActionResult Index()
        {
            List<Docentes_VM> docentes = new List<Docentes_VM>();
            docentes = dc.ListarDocentes();
            return View(docentes);
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int id)
        {
            //Se manda a llamar la lista de categoria academica, en la vista se selecciona el elemento en base al id:categoria en la vista
            Docentes_VM Docente = new Docentes_VM();

            Docente = dc.ListarDocentesId(id);
            return View(Docente);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {

            AgregarDocentes_VM doc = new AgregarDocentes_VM();
            doc.listaCat = dc.ListarCatalogoId(52).ToList();
            return View(doc);
        }

        // POST: Docentes/Create
        [HttpPost]
        public ActionResult Create(AgregarDocentes_VM Docentes)
        {
            
            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if (dc.GuardarDocente(Docentes))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro Guardado", true);
                        return RedirectToAction("Index");
                    }

                    else
                    {

                        // return View(catalogos);

                    }

                }
                // TODO: Add insert logic here
                Danger("Error al guardar registro", true);
                return View(Docentes);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(Docentes);
            }
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int id)
        {
            //Se manda a llamar la lista de categoria academica, en la vista se selecciona el elemento en base al id:categoria en la vista
            AgregarDocentes_VM Docente = new AgregarDocentes_VM();

            Docente = dc.ListarDocentesEditarId(id);
            Docente.listaCat = dc.ListarCatalogoId(52).ToList();
            return View(Docente);
        }

        // POST: Docentes/Edit/5
        [HttpPost]
        public ActionResult Edit(AgregarDocentes_VM Docente)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dc.EditarDocente(Docente))
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
                return View(Docente);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(Docente);
            }
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Docentes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
