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
    public class PeriodoController : BaseController
    {
        Periodo_DL dl = new Periodo_DL();
        // GET: Periodo
        public ActionResult Index()
        {
            List<Periodo_VM> lstPeriodo = new List<Periodo_VM>();
            lstPeriodo = dl.ListarPeriodos();
            return View(lstPeriodo);
        }

        // GET: Periodo/Details/5
        public ActionResult Details(int id)
        {
            Periodo_VM per = new Periodo_VM();
            per = dl.ListarPeriodosId(id);
            return View(per);
        }

        // GET: Periodo/Create
        public ActionResult Create()
        {
            Periodo_VM per = new Periodo_VM();
            return View(per);
        }

        // POST: Periodo/Create
        [HttpPost]
        public ActionResult Create(Periodo_VM periodos)
        {

            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if (dl.GuardarPeriodo(periodos))
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
                return View(periodos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(periodos);
            }
        }

        // GET: Periodo/Edit/5
        public ActionResult Edit(int id)
        {
            Periodo_VM periodoEditar = new Periodo_VM();
            periodoEditar = dl.ListarPeriodosId(id);
            return View(periodoEditar);
        }

        // POST: Periodo/Edit/5
        [HttpPost]
        public ActionResult Edit(Periodo_VM periodoEditar)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarPeriodo(periodoEditar))
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
                return View(periodoEditar);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(periodoEditar);
            }
        }

        // GET: Periodo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Periodo/Delete/5
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
