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

            //Variables para sustituir en html cajillas de selección
            if (Estudiante.trabaja==true)
            {
                ViewBag.Trabaja = "Si (X) No()";
            }
            else
            {
                ViewBag.Trabaja = "Si () No(X)";
            }
            if (Estudiante.id_carrera==6)
            {
                ViewBag.Carrera = "CARRERA: Ing. Electrica(X) Ing. En Computación() Ing. En Telecomunicaciones() Generación 20()";
            }
            else if (Estudiante.id_carrera == 7)
            {
                ViewBag.Carrera = "CARRERA: Ing. Electrica() Ing. En Computación(X) Ing. En Telecomunicaciones() Generación 20()";
            }
            else if (Estudiante.id_carrera == 8)
            {
                ViewBag.Carrera = "CARRERA: Ing. Electrica() Ing. En Computación() Ing. En Telecomunicaciones(X) Generación 20()";
            }
            else if (Estudiante.id_carrera == 9)
            {
                ViewBag.Carrera = "CARRERA: Ing. Electrica() Ing. En Computación() Ing. En Telecomunicaciones() Generación 20(X)";
            }
            else
            {
                ViewBag.Carrera = "CARRERA: Ing. Electrica() Ing. En Computación() Ing. En Telecomunicaciones() Generación 20()";
            }

          


            if (Estudiante.id_sexo==12)
            {
                ViewBag.SexoM = "M(X)";
            }
            else
            {
                ViewBag.SexoM = "M()";
            }

            if (Estudiante.id_sexo == 13)
            {
                ViewBag.SexoF = "F(X)";
            }
            else
            {
                ViewBag.SexoF = "F()";
            }



            if (Estudiante.id_estado_civil == 14)
            {
                ViewBag.EstadoCivil1 = "Casado(X)";
            }
            else
            {
                ViewBag.EstadoCivil1 = "Casado()";
            }

            if (Estudiante.id_estado_civil == 15)
            {
                ViewBag.EstadoCivil2 = "Soltero(X)";
            }
            else
            {
                ViewBag.EstadoCivil2 = "Soltero()";
            }
            //Fin Variables para sustituir en html cajillas de selección
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
