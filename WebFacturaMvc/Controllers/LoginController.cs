using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFacturaMvc.Controllers
{
    public class LoginController : Controller
    {
        private Model.Neg.SeguridadNeg seguridad = new Model.Neg.SeguridadNeg();
        // GET: Login
        public ActionResult Index(string val)
        {
            //obj = new{val = ""};
            ViewBag.MensajeInicio = "Iniciar Sesión "+ val;
            ViewBag.MensajeError =val;
            return View();
        }


        public ActionResult iniciar(string usuario, string pass)
        {
            if (seguridad.iniciar(usuario,pass,Session))
                return RedirectToAction("Index", "Inicio");
            else
                return RedirectToAction("Index", new { val = "Contaseña usuario incorrecto..." });
        }


        [HttpPost]
        public ActionResult comprobar()
        {

            if (seguridad.comprobar(Session))
                return RedirectToAction("Index", "Inicio");
            else
                return RedirectToAction("Index",new { val = "" });
                       
        }


        public ActionResult salir()
        {
            if (seguridad.salir(Session))
            {
                return RedirectToAction("Index", "Incio");
            }
            else
            {
               return RedirectToAction("Index");
            }
        }

        public ActionResult validar(){
            if (Session["usuario"] == null)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index","Inicio");
        }
    }
}