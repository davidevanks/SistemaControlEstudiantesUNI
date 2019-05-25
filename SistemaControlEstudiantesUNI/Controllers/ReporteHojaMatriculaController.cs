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
    public class ReporteHojaMatriculaController : BaseController
    {
        Reportes_DL dl = new Reportes_DL();
        // GET: ReporteHojaMatricula
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
            EstudianteSimple Estudiante = new EstudianteSimple();

            Estudiante = dl.ListarEstudianteDetailsId(Convert.ToInt32(idEstudiante));
            

            return PartialView("rptHojaMatricula", Estudiante);


        }
      
        [HttpPost]
        public ActionResult GetPdf(string html)
        {
            // read parameters from the webpage
            string htmlString = html;
            string baseUrl = "";
            

            string pdf_page_size = "Letter";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
               // webPageWidth = Convert.ToInt32(TxtWidth.Text);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                //webPageHeight = Convert.ToInt32(TxtHeight.Text);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            // doc.Save( false, "Sample.pdf");
            doc.Save(Server.MapPath("~/" + "Sample" + ".pdf"));
            // close pdf document
            doc.Close();

            return Content("Documento Guardado!!");
        }

    }
}
