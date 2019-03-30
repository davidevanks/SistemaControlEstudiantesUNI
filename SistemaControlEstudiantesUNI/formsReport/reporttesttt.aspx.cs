using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaControlEstudiantesUNI.Models;
using SistemaControlEstudiantesUNI.ViewModels;
using Microsoft.Reporting.WebForms;

namespace SistemaControlEstudiantesUNI.formsReport
{
    public partial class reporttesttt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptInscripcionClases_DL dl = new rptInscripcionClases_DL();


                List<rptInscripcionCLases_VM> lstInscripcionClases = new List<rptInscripcionCLases_VM>();

                lstInscripcionClases = dl.leerRptInscripcionClases();
               
              
                   
                    CustomerListReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptInscripcionClases.rdlc");
                    CustomerListReportViewer.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("dsInscripcionClases", lstInscripcionClases);
                    CustomerListReportViewer.LocalReport.DataSources.Add(rdc);
                    CustomerListReportViewer.LocalReport.Refresh();
                    CustomerListReportViewer.DataBind();
                
            }
        }
    }
}