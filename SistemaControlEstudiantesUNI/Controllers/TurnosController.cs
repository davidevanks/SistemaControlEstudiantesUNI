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
    public class TurnosController : BaseController
    {
        Turno_DL dl = new Turno_DL();
        // GET: Turnos
        public ActionResult Index()
        {
            List<Turnos_VM> lstTurnos = new List<Turnos_VM>();
            lstTurnos = dl.ListarTurnos();
            return View(lstTurnos);
        }

        // GET: Turnos/Details/5
        public ActionResult Details(int id)
        {
            Turnos_VM tur = new Turnos_VM();
            tur = dl.ListarTurnoId(id);
            return View(tur);
        }

        // GET: Turnos/Create
        public ActionResult Create()
        {
            Turnos_VM turnos = new Turnos_VM();
            return View(turnos);
        }

        // POST: Turnos/Create
        [HttpPost]
        public ActionResult Create(Turnos_VM turno)
        {
            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if (dl.GuardarTurno(turno))
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
                return View(turno);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(turno);
            }
        }

        // GET: Turnos/Edit/5
        public ActionResult Edit(int id)
        {
            Turnos_VM Turno = new Turnos_VM();
            Turno = dl.ListarTurnoId(id);
            return View(Turno);
        }

        // POST: Turnos/Edit/5
        [HttpPost]
        public ActionResult Edit(Turnos_VM turno)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarTurno(turno))
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
                return View(turno);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(turno);
            }
        }

        // GET: Turnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Turnos/Delete/5
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
