using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public Area Area { get; set; }

        public bool Disponible { get; set; }
    }

}
