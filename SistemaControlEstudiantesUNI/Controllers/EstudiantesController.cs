using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.ViewModels;
using SistemaControlEstudiantesUNI.Models;


namespace SistemaControlEstudiantesUNI.Controllers
{
    public class EstudiantesController : BaseController
    {
        Estudiantes_DL dl = new Estudiantes_DL();
        // GET: Estudiantes
      
        public ActionResult Index( EstudianteSimple lstes)
        {
            List<EstudianteSimple> lstEstudiante = new List<EstudianteSimple>();
            lstEstudiante = dl.ListarEstudiante();
            return View(lstEstudiante);
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiantes/Create
        
        public ActionResult Create()
        {


            AgregarEstudiante estudiante = new AgregarEstudiante();
            estudiante.Carreras = dl.lstCatalogos(1);
            estudiante.Departamentos = dl.lstDepartamentos();
            estudiante.Municipios = dl.lstMunicipio(1);
            estudiante.planEstudios = dl.lstCatalogos(5);
            estudiante.Sexos = dl.lstCatalogos(4);
            estudiante.Turnos = dl.lstTurnos();
            estudiante.estadoCiviles = dl.lstCatalogos(3);
            estudiante.fecha_grabacion = DateTime.Now;
            estudiante.fecha_ingreso = DateTime.Now;
            estudiante.fecha_nacimiento = DateTime.Now;
            Session["Modelo"] = estudiante;
            return View(estudiante);
        }

        [HttpGet]
        public ActionResult GetRegions(string id)
        {
            //if (!string.IsNullOrWhiteSpace(id) && id.Length == 3)
            //{
               

                IEnumerable<localidad> Municipios = dl.lstMunicipio(Convert.ToInt32(id));
                return Json(Municipios, JsonRequestBehavior.AllowGet);
            //}
            //return null;
        }


        // POST: Estudiantes/Create
        [HttpPost]
        public ActionResult Create(AgregarEstudiante est)
        {
            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if (dl.GuardarEstudiante(est))
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
                return View(est);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(est);
            }
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiantes/Edit/5
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

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiantes/Delete/5
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
