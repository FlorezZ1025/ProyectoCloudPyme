using ProyectoCloudPyme.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProyectoCloudPyme.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
  
        [HttpPost]
        public ActionResult Save(Archivo model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathAtchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.png");
            string PathAtchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.png");
            if (!ModelState.IsValid)
            {
               return RedirectToAction("SubirArchivos","Home",new { model });
            }
            model.archivo1.SaveAs(PathAtchivo1);
            model.archivo2.SaveAs(PathAtchivo2);
            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("SubirArchivos","Home");

        }
    }
}