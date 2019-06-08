using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class estudianteAsignaturaController : BaseController
    {

        estudianteAsignatura_DL dl = new estudianteAsignatura_DL();
        // GET: estudianteAsignatura
        public ActionResult Index()
        {
            List<estudianteAsignaturaSimple_VM> lstEstudianteAsignatura = new List<estudianteAsignaturaSimple_VM>();
            lstEstudianteAsignatura = dl.ListarEstudiantesAsignatura();
            return View(lstEstudianteAsignatura);
        }

        // GET: estudianteAsignatura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: estudianteAsignatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estudianteAsignatura/Create
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

        // GET: estudianteAsignatura/Edit/5
        public ActionResult Edit(int id)
        {
            AgregarEstudianteAsignatura_VM asig = new AgregarEstudianteAsignatura_VM();
            asig = dl.ListarEstudianteAsigEditar(id);
            asig.lstHijosEsAsig = dl.ListarHijosEstudianteAsig(id);
            Session["idestudiante"] = id;
            Session["idPeriodo"] = asig.id_periodo;
            Session["anioPeriodo"] = asig.anioPeriodo;
            return View(asig);
        }

        // POST: estudianteAsignatura/Edit/5
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

        // GET: estudianteAsignatura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: estudianteAsignatura/Delete/5
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

        //Metodos de vistas adicionales de tabala interna
        public ActionResult AsignarClase()
        {
            AgregarHijosEstudianteAsignatura hijos = new AgregarHijosEstudianteAsignatura();
            hijos.Asignatura = dl.lstAsignaturas();
            hijos.Docente = dl.lstDocente();
            hijos.Grupo = dl.lstGrupos();
            hijos.id_estudiante = Convert.ToInt32(Session["idestudiante"]);
            hijos.id_periodo= Convert.ToInt32(Session["idPeriodo"]);
            return View(hijos);
        }


        [HttpPost]
        public ActionResult AsignarClase(AgregarHijosEstudianteAsignatura asig)
        {
            asig.Asignatura = dl.lstAsignaturas();
            asig.Docente = dl.lstDocente();
            asig.Grupo = dl.lstGrupos();
            asig.anioPeriodo = (int)Session["anioPeriodo"];
            try
            {
                //Docentes.listaCat= dc.ListarCatalogoId(52).ToList();
                if (ModelState.IsValid)
                {
                    if(dl.ValidarAsignatura((Int32)asig.id_estudiante,(Int32)asig.id_asignatura))
                    {
                        if (dl.GuardarAsignacionClase(asig))
                        {
                            int idd = Convert.ToInt32(Session["idestudiante"]);
                            //Mandar msj de confirmación de guardado
                            Success("Clase Asignada!", true);
                            return RedirectToAction("Edit", new { id = Convert.ToInt32(Session["idestudiante"]) });
                        }

                        else
                        {

                            // return View(catalogos);
                            Danger("Alumno ya tiene asignada esta asignatura o ya fue aprobada en un periodo anterior!", true);
                            return View(asig);
                        }
                    }
                    else
                    {
                        Danger("No se puede asignar clase debido a que alumno no aprueba clase dependiente aún!", true);
                        return View(asig);
                    }
                   

                }
                // TODO: Add insert logic here
                Danger("Error al asignar clase", true);
                return View(asig);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al asignar clase: " + ex.ToString(), true);
                return View(asig);
            }
        }




        public ActionResult EditAsignacion(int id)
        {
            AgregarHijosEstudianteAsignatura hijos = new AgregarHijosEstudianteAsignatura();
            hijos = dl.ListarAsignarClasesEditar(id);
            
            hijos.Asignatura = dl.lstAsignaturas();
            hijos.Docente = dl.lstDocente();
            hijos.Grupo = dl.lstGrupos();
            hijos.id_estudiante = Convert.ToInt32(Session["idestudiante"]);
            hijos.id_periodo = Convert.ToInt32(Session["idPeriodo"]);
            return View(hijos);
        }

        // POST: estudianteAsignatura/Edit/5
        [HttpPost]
        public ActionResult EditAsignacion(AgregarHijosEstudianteAsignatura hijos)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EditarHijos(hijos))
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
                return View(hijos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al guardar registro: " + ex.ToString(), true);
                return View(hijos);
            }
        }



        public ActionResult EliminarAsignacion(int id)
        {
            AgregarHijosEstudianteAsignatura hijos = new AgregarHijosEstudianteAsignatura();
            hijos = dl.ListarAsignarClasesEditar(id);

            hijos.Asignatura = dl.lstAsignaturas();
            hijos.Docente = dl.lstDocente();
            hijos.Grupo = dl.lstGrupos();
            hijos.id_estudiante = Convert.ToInt32(Session["idestudiante"]);
            hijos.id_periodo = Convert.ToInt32(Session["idPeriodo"]);
            return View(hijos);
        }

        // POST: estudianteAsignatura/Edit/5
        [HttpPost]
        public ActionResult EliminarAsignacion(AgregarHijosEstudianteAsignatura hijos)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (dl.EliminarHijos(hijos))
                    {
                        //Mandar msj de confirmación de guardado
                        Success("Registro eliminado!", true);
                        return RedirectToAction("Index");
                    }

                    else
                    {

                        // return View(catalogos);

                    }

                }
                // TODO: Add insert logic here
                Danger("Error al eliminar registro", true);
                return View(hijos);

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                Danger("Error al eliminar registro: " + ex.ToString(), true);
                return View(hijos);
            }
        }

        //
    }
}
