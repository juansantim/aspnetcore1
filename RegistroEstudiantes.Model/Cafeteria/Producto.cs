using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroEstudiantes.Model.Cafeteria
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [NotMapped]
        public bool Visible { get; set; }
    }
}
