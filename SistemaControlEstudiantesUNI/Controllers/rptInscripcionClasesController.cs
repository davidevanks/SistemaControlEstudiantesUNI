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
    public class rptInscripcionClasesController : BaseController
    {
        rptInscripcionClases_DL dl = new rptInscripcionClases_DL();
        // GET: rptInscripcionClases
        public ActionResult Index()
        {
            return View();
        }


        DataSet ds = new DataSet();

        public ActionResult ReportInscripcionClases()
        {

            List<rptInscripcionCLases_VM> lstInscripcionClases = new List<rptInscripcionCLases_VM>();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;

            lstInscripcionClases = dl.leerRptInscripcionClases();
            DataTable dt = new DataTable();

          
            //         = x.Carreara,
            //         = x.Turno,

            //         = x.PlanEstudio,
            //         = x.NombreApellido,
            //         = x.EstadoCivil,
            //         = x.Sexo,
            //         = x.no_cedula,
            //         = (int)x.edad,
            //         = x.direccion_habitual,
            //         = x.email,
            //         = x.celular,

            //         = x.fecha_ingreso.ToString(),
            //         = x.nombreAsignatura,
            //         = x.horario,
            //         = x.Docente,
            //         = x.Periodo

            dt.Columns.Add("idEstudiante", typeof(string));
            dt.Columns.Add("no_carnet", typeof(string));

            dt.Columns.Add("Carreara", typeof(string));
            dt.Columns.Add("Turno", typeof(string));
            dt.Columns.Add("PlanEstudio", typeof(string));
            dt.Columns.Add("NombreApellido", typeof(string));
            dt.Columns.Add("EstadoCivil", typeof(string));
            dt.Columns.Add("Sexo", typeof(string));
            dt.Columns.Add("no_cedula", typeof(string));

            dt.Columns.Add("edad", typeof(string));
            dt.Columns.Add("direccion_habitual", typeof(string));
            dt.Columns.Add("celular", typeof(string));
            dt.Columns.Add("fechaIngreso", typeof(string));
            dt.Columns.Add("nombreAsignatura", typeof(string));
            dt.Columns.Add("horario", typeof(string));
            dt.Columns.Add("Docente", typeof(string));
            dt.Columns.Add("Periodo", typeof(string));
          
            

            //
            foreach (var item in lstInscripcionClases)
            {
                DataRow dr = dt.NewRow();
              
                dr["idEstudiante"]=item.idEstudiante;
                dr["no_carnet"]=item.no_carnet;

                dr["Carreara"]=item.Carreara;
                dr["Turno"]=item.Turno;
                dr["PlanEstudio"]=item.PlanEstudio;
                dr["NombreApellido"]=item.NombreApellido;
                dr["EstadoCivil"]=item.EstadoCivil;
                dr["Sexo"]=item.Sexo;
                dr["no_cedula"]=item.no_cedula;

                dr["edad"]=item.edad;
                dr["direccion_habitual"]=item.direccion_habitual;
                dr["celular"]=item.celular;
                dr["fechaIngreso"]=item.fechaIngreso;
                dr["nombreAsignatura"]=item.nombreAsignatura;
                dr["horario"]=item.horario;
                dr["Docente"]=item.Docente;
                dr["Periodo"]=item.Periodo;

                dt.Rows.Add(dr);

            }


            ds.Tables.Add(dt);


            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reportes\rptInscripcionClases.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsInscripcionClases", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;

            return View();
        }


    }
}
