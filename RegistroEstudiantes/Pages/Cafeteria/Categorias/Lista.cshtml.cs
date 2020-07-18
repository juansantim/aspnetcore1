using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Dto;

namespace RegistroEstudiantes.Pages.Cafeteria.Categorias
{
    public class ListaModel : PageModel
    {
        private readonly RegistroEstudiantesContext db;
        private readonly ILogger<ListaModel> logger;

        public List<CategoriaDto> Categorias { get; set; }

        public ListaModel(RegistroEstudiantesContext db, ILogger<ListaModel> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogError("Ingresó a Listar Categorias");

            var categorias = db.Categorias.Include(c => c.Productos).ToList();

            this.Categorias = categorias.Select(c => new CategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                CantidadDeProductos = c.Productos.Count
            }).ToList();
        }
    }
}