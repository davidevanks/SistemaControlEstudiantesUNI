using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.ViewModels;
using SistemaControlEstudiantesUNI.Models;

namespace SistemaControlEstudiantesUNI.Controllers
{
    //[Authorize(Roles = "Admin")]
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


        [HttpGet]
        public ActionResult GetGrupos(string id)
        {
            //if (!string.IsNullOrWhiteSpace(id) && id.Length == 3)
            //{


            IEnumerable<GrupoNotas_VM> Grupos = dl.ListarGrupos(Convert.ToInt32(id));
            return Json(Grupos, JsonRequestBehavior.AllowGet);
            //}
            //return null;
        }

        [HttpGet]
        public ActionResult GetAsig(string iddoc,string idGrp)
        {
            //if (!string.IsNullOrWhiteSpace(id) && id.Length == 3)
            //{


            IEnumerable<AsignaturaNotas_VM> Asignaturas = dl.ListarAsignatura(Convert.ToInt32(iddoc), Convert.ToInt32(idGrp));
            return Json(Asignaturas, JsonRequestBehavior.AllowGet);
            //}
            //return null;
        }


        [HttpGet]
        public PartialViewResult GetEstudiantes(string docente, string grupo,string asignatura)
        {
            //if (!string.IsNullOrWhiteSpace(id) && id.Length == 3)
            //{
            int idDoc = Convert.ToInt32(docente);
            int idGr= Convert.ToInt32(grupo);
            int idAsig = Convert.ToInt32(asignatura);

            EstudianteEditarNotas_VM estudiante = new EstudianteEditarNotas_VM();
            estudiante.estudiantes = dl.ListarEstudiante(idDoc,idGr,idAsig);
            //return Json(estudiante.estudiantes, JsonRequestBehavior.AllowGet);
            return PartialView("_estudiantes", estudiante);
            //}
            //return null;
        }

    }
}
