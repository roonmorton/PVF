using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFacturaMvc.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            Model.Neg.SeguridadNeg seg = new SeguridadNeg();
            if(seg.comprobar(Session)){
                
                VentaNeg objVentaNeg = new VentaNeg();
                List<Venta> lista = objVentaNeg.findAll();
                return View(lista);
            }else{
                return RedirectToAction("Index","Login");
            }
        }
    }
}