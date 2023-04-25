using ProyectoCloudPyme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult MostrarLinkAlimentos()
        {
            return View();
        }

        public ActionResult MostrarLinkComercio()
        {
            return View();
        }

        public ActionResult MostrarLinkTransporte()
        {
            return View();
        }

        public ActionResult MostrarLinks()
        {
            string tipoPyme = Request.Form["tipoPyme"];
            if(tipoPyme == "Alimentos")
            {
                return RedirectToAction("MostrarLinkAlimentos");
            }
            else if(tipoPyme == "Comercio")
            {
                return RedirectToAction("MostrarLinkComercio");
            }
            else if(tipoPyme == "")
            {

                return RedirectToAction("MostrarLinkTransporte");
            }
            return RedirectToAction("crearPyme");


        }

        public ActionResult CrearPyme()
        {
            return View();
        }
        public ActionResult PaginaUsuario()
        {
            string email = (string)TempData["email"];
            TempData.Keep("email");
            string contraseña = (string)TempData["contraseña"];
            TempData.Keep("contraseña");

            Usuario usuario = mipagina.TraerUsuario(email, contraseña);
            return View(usuario);
        }
        public ActionResult VerificarExistencia()
        {
            
            string email = Request.Form["email"];
            string contraseña = Request.Form["contraseña"];

            if (mipagina.EstaRegistrado(email) && mipagina.ContraValida(contraseña))
            {
                TempData["email"] = email;
                TempData["contraseña"] = contraseña;
                TempData.Keep("email");
                TempData.Keep("contraseña");

                //Usuario usuario = mipagina.TraerUsuario(email, contraseña);
                  
                    //aqui va un alert
                return RedirectToAction("PaginaUsuario");
                
            }
            //aqui va un alert
            return RedirectToAction("iniciarSesion");
        }

        public ActionResult capturardatosRegistro() 
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            string nombre = Request.Form["nombre"];
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

    }

}