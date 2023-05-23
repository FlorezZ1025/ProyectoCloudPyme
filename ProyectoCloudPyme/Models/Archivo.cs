using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCloudPyme.Models
{
    public class Archivo
    {
        [Required]
        [DisplayName("Mi RUT")]
        public HttpPostedFileBase archivo1 { get; set; }


        [Required]
        [DisplayName("Mi licencia")]
        public HttpPostedFileBase archivo2 { get; set; }

    
    }
}