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
    public class ReporteCertificadoFinalNotasController : Controller
    {
        Reportes_DL dl = new Reportes_DL();
        // GET: ReporteConstanciaNotasInd
        public ActionResult Index()
        {
            List<ListaConstanciaNotas> lstEstudiante = new List<ListaConstanciaNotas>();
            lstEstudiante = dl.GetListaEstudiantesConsNotas();
            ViewBag.estudiantes = lstEstudiante;
            return View(lstEstudiante);
        }

        public PartialViewResult GetReporte(string idEstudiante)

        {
            //El paginado se maneja desde la base de datos, desde el codigo se mandan los parametros del paginado. (# de páginas, # página actual)
            //Cantidad de registros a mostrar por página
            rptConstanciaNotasIndividual_VM Estudiante = new rptConstanciaNotasIndividual_VM();
            Estudiante = dl.GetListaEstudiantesNotasDetalle(Convert.ToInt32(idEstudiante));
            Estudiante.LstPeriodos = dl.GetListaConstanciaNotasPeriodos(Convert.ToInt32(idEstudiante));
            Estudiante.LstAsignaturas = dl.GetListaCertificadoFinalNotasAsignaturas(Convert.ToInt32(idEstudiante));
            //Variables para sustituir en html cajillas de selección

            //Fin Variables para sustituir en html cajillas de selección
            return PartialView("rptCertificadoFinalNotas", Estudiante);


        }
    }
}