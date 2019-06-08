using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;
using SelectPdf;
using Microsoft.Ajax.Utilities;

namespace SistemaControlEstudiantesUNI.Controllers
{
    public class ReporteConstanciaIndividualController : Controller
    {
        Reportes_DL dl = new Reportes_DL();
        // GET: ReporteConstanciaIndividual
        public ActionResult Index()
        {
            List<estudiante> lstEstudiante = new List<estudiante>();
            lstEstudiante = dl.ListarEstudiantes();
            ViewBag.estudiantes = lstEstudiante;
            return View(lstEstudiante);
        }


        public PartialViewResult GetReporte(string idEstudiante)

        {
            //El paginado se maneja desde la base de datos, desde el codigo se mandan los parametros del paginado. (# de páginas, # página actual)
            //Cantidad de registros a mostrar por página
            rptConstanciaIndividual_VM Estudiante = new rptConstanciaIndividual_VM();

            Estudiante = dl.GetRptConstanciaIndividual(Convert.ToInt32(idEstudiante));

            //Variables para sustituir en html cajillas de selección
       
            //Fin Variables para sustituir en html cajillas de selección
            return PartialView("rptConstanciaIndividual", Estudiante);


        }

    }
}
