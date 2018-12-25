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
    [Authorize(Roles = "Admin")]
    public  class AsignaturaController : BaseController
    {
       
        Asignaturas_DL dl = new Asignaturas_DL();
        // GET: Asignatura
        public ActionResult Index()
        {
            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();
            lstAsignaturas = dl.ListarAsignaturas();
            return View(lstAsignaturas);
        }

        // GET: Asignatura/Details/5
        public ActionResult Details(int id)
        {
            AsignaturaSimple_VM asig = new   AsignaturaSimple_VM();
            asig = dl.ListarAsignaturasDetalle(id).FirstOrDefault();



            return View(asig);
        }

        // GET: Asignatura/Create
        public ActionResult Create()
        {
            Asignaturas_VM Asignatura = new Asignaturas_VM();
         
            Asignatura.asignaturasRequisitos = dl.ListarAsignaturasRequisitos().ToList();
           
            return View(Asignatura);
        }

        // POST: Asignatura/Create
        [HttpPost]
        public ActionResult Create(Asignaturas_VM asignatura)
        {
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if (dl.guardarAsignatura(asignatura))
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
                return View(asignatura);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(asignatura);
            }
        }

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int id)
        {
            Asignaturas_VM asig = new Asignaturas_VM();
            asig = dl.ListarAsignaturasEditarId(id);
            asig.asignaturasRequisitos = dl.ListarAsignaturasRequisitosEditar().ToList();
            return View(asig);
        }

        // POST: Asignatura/Edit/5
        [HttpPost]
        public ActionResult Edit(Asignaturas_VM asig)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarAsignatura(asig))
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
                return View(asig);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(asig);
            }
        }

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asignatura/Delete/5
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
