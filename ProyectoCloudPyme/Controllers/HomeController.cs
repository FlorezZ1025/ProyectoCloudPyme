using Microsoft.Ajax.Utilities;
using ProyectoCloudPyme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Web;
using System.Web.Mvc;
using static ProyectoCloudPyme.Models.Enum;

namespace ProyectoCloudPyme.Controllers
{
    public class HomeController : SweetController
    {
        Pagina mipagina = new Pagina();
        int cont = 0;
        public ActionResult SubirArchivos()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }
            return View();
        }

        public ActionResult BienvenidaUsuario()
        {
            if (cont == 0)
            {
                cont = 1;
                mipagina.UsuarioAleatorio();
            }
            return View();  
        }

        public ActionResult InicioDeSesion() {
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
        public ActionResult EditarUsuario()
        {
            string email = (string)TempData["email"];
            TempData.Keep("email");
            string contraseña = (string)TempData["contraseña"];
            TempData.Keep("contraseña");

            Usuario usuario = mipagina.TraerUsuario(email, contraseña);

            return View(usuario);
        }

        public ActionResult GuiaPymeAlimentos()
        {
            return View();
        }

        public ActionResult GuiaPymeComercio()
        {
            return View();
        }

        public ActionResult GuiaPymeTransporte()
        {
            return View();
        }
        public ActionResult CapturarDatosPyme(){

            string email = (string)TempData["email"];
            TempData.Keep("email");
            string contraseña = (string)TempData["contraseña"];
            TempData.Keep("contraseña");

            Usuario usuario = mipagina.TraerUsuario(email, contraseña);

            string nombrePyme = Request.Form["nombrePyme"];
            string descripcion = Request.Form["Descripcion"];
            string tipoPyme = Request.Form["tipoPyme"];

            if (tipoPyme == "Comercio")
            {
                Comercio pymeComercio = new Comercio(nombrePyme,usuario, descripcion);
                usuario.Pymes.Add(pymeComercio);
            }
            else if (tipoPyme == "Transporte")
            {
                Transporte pymeTransporte = new Transporte(nombrePyme, usuario, descripcion);
                usuario.Pymes.Add(pymeTransporte);
            }
            else
            {
                Alimento pymeAlimento = new Alimento(nombrePyme,usuario,descripcion);
                usuario.Pymes.Add(pymeAlimento);
            }

            return RedirectToAction("SubirArchivos");
        }

        public ActionResult AccederSubirArchivos()
        {

            //También le puede pasar un usuario, atento
            return View("~/Views/Archivo/SubirArchivos.cshtml");
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

                
                return RedirectToAction("PaginaUsuario");
                
            }

            Alert("No se encontró el usuario",NotificationType.error);
            //aqui va un alert
            return RedirectToAction("InicioDeSesion");
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

            return RedirectToAction("InicioDeSesion");
        }

        public ActionResult ElegirPyme() 
        {
            return View();
        }

        public ActionResult CapturarDatosEdicion()
        {
            string nombre = Request.Form["nombre"];
            string apellido_1 = Request.Form["apellido_1"];
            string apellido_2 = Request.Form["apellido_2"];
            DateTime fhnacimiento = DateTime.Parse(Request.Form["fh_nacimiento"]);
            

            string email = (string)TempData["email"];
            TempData.Keep("email");
            string contraseña = (string)TempData["contraseña"];
            TempData.Keep("contraseña");

            Usuario usuario = mipagina.TraerUsuario(email, contraseña);

            usuario.Nombre = nombre;
            usuario.Apellido_1 = apellido_1;
            usuario.Apellido_2 = apellido_2;

            return RedirectToAction("VisualizarInformacion");

            
        }
        public ActionResult VisualizarInformacion()
        { 
            string email = (string)TempData["email"];
            TempData.Keep("email");
            string contraseña = (string)TempData["contraseña"];
            TempData.Keep("contraseña");

            Usuario usuario = mipagina.TraerUsuario(email, contraseña);

            return View(usuario);
        }


    }

}