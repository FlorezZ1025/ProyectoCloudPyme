using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCloudPyme.Models
{
    public abstract class Pyme
    {
        private string nombre_pyme;
        private string tipo_pyme;
        private Usuario usuario_pyme;
        private string descripcion;

        public Pyme(string nombre_pyme, Usuario usuario_pyme, string descripcion, string tipo_pyme)
        {
            this.nombre_pyme = nombre_pyme;
            this.usuario_pyme = usuario_pyme;
            this.descripcion = descripcion;
            this.tipo_pyme = tipo_pyme;
        }

        public string Nombre_pyme { get => nombre_pyme; set => nombre_pyme = value; }
        public string Tipo_pyme { get => tipo_pyme; set => tipo_pyme = value; }
        public Usuario Usuario_pyme { get => usuario_pyme; set => usuario_pyme = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}