using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCloudPyme.Models
{
    public class Pyme
    {
        private string nombre_pyme;
        private string tipo_pyme;
        private Usuario usuario_pyme;
        private int num_empleados;
        private string descripcion;

        public Pyme(string nombre_pyme, string tipo_pyme, Usuario usuario_pyme, int num_empleados, string descripcion)
        {
            this.nombre_pyme = nombre_pyme;
            this.tipo_pyme = tipo_pyme;
            this.usuario_pyme = usuario_pyme;
            this.num_empleados = num_empleados;
            this.descripcion = descripcion;
        }

        public string Nombre_pyme { get => nombre_pyme; set => nombre_pyme = value; }
        public string Tipo_pyme { get => tipo_pyme; set => tipo_pyme = value; }
        public Usuario Usuario_pyme { get => usuario_pyme; set => usuario_pyme = value; }
        public int Num_empleados { get => num_empleados; set => num_empleados = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}