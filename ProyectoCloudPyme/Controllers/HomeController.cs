using ProyectoCloudPyme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoCloudPyme.Controllers
{
    public class HomeController : Controller
    {
        Pagina mipagina = new Pagina();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registrar()
        {
            return View();
    
        }

        public ActionResult capturardatosRegistro() {
            int id = Convert.ToInt32(Request.Form["id"]);
            string nombre = Request.Form["name"];
            string apellido_1 = Request.Form["apellido_1"];
            string apellido_2 = Request.Form["apellido_2"];
            DateTime fhnacimiento = DateTime.Parse(Request.Form["fh_nacimiento"]);
            string email = Request.Form["email"];
            string contraseña = Request.Form["contraseña"];

            Usuario usuario = new Usuario(id,nombre, apellido_1, apellido_2,fhnacimiento,email,contraseña);

            mipagina.AgregarUsuario(usuario);

            return RedirectToAction("IniciarSesion");
        }
        public ActionResult IniciarSesion()
        {
            return View();
        }

        public ActionResult VerificarExistencia()
        {
            string email = Request.Form["email"];
            string contraseña = Request.Form["contraseña"];

            if (mipagina.EstaRegistrado(email) && mipagina.ContraValida(contraseña))
            {
                    //aqui va un alert
                  return RedirectToAction("PaginaUsuario");
                
            }
            //aqui va un alert
            return RedirectToAction("iniciarSesion");
        }
    }

}