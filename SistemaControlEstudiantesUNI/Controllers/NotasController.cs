using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.ViewModels;
using SistemaControlEstudiantesUNI.Models;

namespace SistemaControlEstudiantesUNI.Controllers
{
    public class NotasController : BaseController
    {

        EditarNotas_DL dl = new EditarNotas_DL();
        // GET: Notas
        public ActionResult Index()
        {

            EstudianteEditarNotas_VM lstEstudiante = new EstudianteEditarNotas_VM();
            // ViewBag.Client = new SelectList(repository.GetClient(), "UserID", "Name");
            lstEstudiante.docentes = dl.ListarDocentes();
            lstEstudiante.Grupos = dl.ListarGrupos(0);
            lstEstudiante.Asignaturas = dl.ListarAsignatura(0,0);
            lstEstudiante.estudiantes = dl.ListarEstudiante(0,0,0);
            //aqui quede
            return View(lstEstudiante);
        }

        // GET: Notas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notas/Delete/5
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
