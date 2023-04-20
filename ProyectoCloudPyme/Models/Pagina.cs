using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ProyectoCloudPyme.Models
{
    public class Pagina
    {
        private List<Usuario> usuarios = new List<Usuario>();
        public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; } 

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool EstaRegistrado(string email)
        {
            foreach (Usuario usuario_ in usuarios)
            {
                if (usuario_.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContraseñaValida(string contraseña)
        {
            foreach (Usuario usuario_ in usuarios)
            {
                if (usuario_.Contraseña == contraseña)
                {
                    return true;
                }
            }
            return false;
        }
        

    }
}