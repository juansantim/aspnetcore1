using RegistroEstudiantes.Model.Papeleria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEstudiantes.DTOs
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }

        public int CantidadProductos { get; set; }
    }
}
