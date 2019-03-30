using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;
using SistemaControlEstudiantesUNI.Controllers;
using System.ComponentModel;
using SistemaControlEstudiantesUNI.Utiles;

namespace SistemaControlEstudiantesUNI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ReportesController : Controller
    {
        Asignaturas_DL dl = new Asignaturas_DL();
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        DataSet ds = new DataSet();

        public ActionResult ReportEmployee()
        {

            List<AsignaturaSimple_VM> lstAsignaturas = new List<AsignaturaSimple_VM>();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            lstAsignaturas = dl.ListarAsignaturas();
            DataTable dt = new DataTable();
            
            //
            dt.Columns.Add("codigoAsignatura", typeof(string));
            dt.Columns.Add("asignatura", typeof(string));
            //
            foreach (var item in lstAsignaturas)
            {
                DataRow dr = dt.NewRow();
                dr["codigoAsignatura"] = item.codigoAsignatura;
                dr["asignatura"] = item.asignatura;

                dt.Rows.Add(dr);

            }


            ds.Tables.Add(dt);


            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\rptAsignaturas.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsAsignaturas", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }


    }
}