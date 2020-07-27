using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
