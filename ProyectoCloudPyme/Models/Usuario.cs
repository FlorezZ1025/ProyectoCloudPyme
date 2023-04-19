using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCloudPyme.Models
{
    public class Usuario
    {
        private int      id;
        private string   nombre;
        private string   apellido_1;
        private string   apellido_2;
        private DateTime fhnacimiento;
        private string   contraseña;
        private string   email;

        public Usuario(int id, string nombre, string apellido_1, string apellido_2, DateTime fhnacimiento, string contraseña, string email)
        {
            this.Id           = id;
            this.Nombre       = nombre;
            this.Apellido_1   = apellido_1;
            this.Apellido_2   = apellido_2;
            this.Fhnacimiento = fhnacimiento;
            this.Contraseña   = contraseña;
            this.Email        = email;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido_1 { get => apellido_1; set => apellido_1 = value; }
        public string Apellido_2 { get => apellido_2; set => apellido_2 = value; }
        public DateTime Fhnacimiento { get => fhnacimiento; set => fhnacimiento = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Email { get => email; set => email = value; }
    }
}