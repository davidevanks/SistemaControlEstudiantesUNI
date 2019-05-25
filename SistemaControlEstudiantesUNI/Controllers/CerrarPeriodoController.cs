using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControlEstudiantesUNI.Models;

namespace SistemaControlEstudiantesUNI.Controllers
{
    public class CerrarPeriodoController : BaseController
    {
        CerrarCiclo_DL dl = new CerrarCiclo_DL();
        // GET: CerrarPeriodo
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult CerrarPeriodoCiclo()
        {

           
            if(dl.CerrarCiclo()==true)
            {
                Success("Cierre de Ciclo Completo!!", true);
                return RedirectToAction("Index");
            }
            else
            {
                Danger("Error al Cerrar Ciclo!!!",true);
                return RedirectToAction("Index");
            }

           
        }
    }
}