using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaControlEstudiantesUNI.Controllers
{
    public class ReporteInscripcionClasesController : Controller
    {
        Reportes_DL dl = new Reportes_DL();
        // GET: ReporteInscripcionClases
        public ActionResult Index()
        {
            List<estudiante> lstEstudiante = new List<estudiante>();
            lstEstudiante = dl.ListarEstudiantesInscripcion() ;
            ViewBag.estudiantes = lstEstudiante;
            return View(lstEstudiante);
        }


        public PartialViewResult GetReporte(string idEstudiante)

        {
            //El paginado se maneja desde la base de datos, desde el codigo se mandan los parametros del paginado. (# de páginas, # página actual)
            //Cantidad de registros a mostrar por página
            rptInscripcionCLases_VM Estudiante = new rptInscripcionCLases_VM();

            Estudiante = dl.GetRptInscripciónClase(Convert.ToInt32(idEstudiante));
            Estudiante.ListaAsignaturas = dl.GetDetalleRptInscripciónClase(Convert.ToInt32(idEstudiante));

            //Variables para sustituir en html cajillas de selección
            if(Estudiante.Sexo== "Masculino")
            {
                ViewBag.Sexo = " Sexo: M(X) F()";
            }
            else
            {
                ViewBag.Sexo = " Sexo: M() F(X)";
            }
            //Fin Variables para sustituir en html cajillas de selección
            return PartialView("rptInscripcionClases", Estudiante);


        }
    }
}