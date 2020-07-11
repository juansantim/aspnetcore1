using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Model.Papeleria;

namespace RegistroEstudiantes.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly RegistroEstudiantesContext db;

        public CategoriasController(RegistroEstudiantesContext db)
        {
            this.db = db;
        }

        [Route("Guardar")]
        public int Guadar(Categoria categoria) 
        {
            if (categoria.Id == 0)
            {
                db.Categorias.Add(categoria);
            }
            else
            {
                db.Categorias.Add(categoria);
                db.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (var item in categoria.Productos)
                {
                    db.Productos.Add(item);
                    if (item.Id > 0)
                    {
                        db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }                    
                }
            }

            db.SaveChanges();

            return categoria.Id;
        }

        [Route("GetCategoria")]
        public Categoria GetCategoria(int Id) 
        {
            var categoria = db.Categorias.SingleOrDefault(c => c.Id == Id);

            categoria.Productos = db.Productos.Where(p => p.CategoriaId == Id).ToList();

            foreach (var p in categoria.Productos)
            {
                p.Categoria = null;
            }

            return categoria;
        }
    }
}
