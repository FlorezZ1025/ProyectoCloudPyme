﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCloudPyme.Models
{
    public class Alimento:Pyme
    {
        private string nombre_pyme;
        private string tipo_pyme;
        private Usuario usuario_pyme;
        private string descripcion;


        public Alimento(string nombre_pyme, Usuario usuario_pyme, string descripcion) :
            base(nombre_pyme, usuario_pyme, descripcion, "Alimento")
        {
            this.nombre_pyme = nombre_pyme;
            //this.tipo_pyme = "Alimento";
            this.usuario_pyme = usuario_pyme;
            this.descripcion = descripcion;
        }
        public new string Nombre_pyme { get => nombre_pyme; set => nombre_pyme = value; }
        public new string Tipo_pyme { get => tipo_pyme; set => tipo_pyme = value; }
        public new Usuario Usuario_pyme { get => usuario_pyme; set => usuario_pyme = value; }
        public new string Descripcion { get => descripcion; set => descripcion = value; }
    }

}