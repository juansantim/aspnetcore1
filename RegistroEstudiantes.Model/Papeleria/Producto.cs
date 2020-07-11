using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Model.Papeleria
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
