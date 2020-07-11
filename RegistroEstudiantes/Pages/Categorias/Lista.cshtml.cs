using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.DTOs;
using RegistroEstudiantes.Model.Papeleria;

namespace RegistroEstudiantes.Pages.Categorias
{
    public class ListaModel : PageModel
    {
        public List<CategoriaDto> ListaCategorias { get; set; }

        private readonly RegistroEstudiantesContext db;

        public ListaModel(RegistroEstudiantesContext db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            var categorias = db.Categorias.ToList();

            this.ListaCategorias = categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CantidadProductos = db.Productos.Where(p => p.CategoriaId == c.Id).Count()
            }).ToList();
        }
    }
}