using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Model.Cafeteria;

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

        [Route("GetCategoria")]
        public Categoria GetCategoria(int Id) 
        {
            var categoria = db.Categorias.Include(c => c.Productos).SingleOrDefault(c => c.Id == Id);

            foreach (var producto in categoria.Productos)
            {
                producto.Categoria = null;
            }

            return categoria;
        }

        [Route("Guardar")]
        public Categoria Guardar(Categoria categoria) 
        {
            if (categoria.Id == 0)
            {
                db.Categorias.Add(categoria);
            }
            else 
            {
                db.Categorias.Add(categoria);
                db.Entry(categoria).State = EntityState.Modified;

                foreach (var prod in categoria.Productos)
                {
                    db.Productos.Add(prod);
                    
                    if (prod.Id > 0) 
                    {
                        db.Entry(prod).State = EntityState.Modified;
                    }
                }
            }

            db.SaveChanges();

            foreach (var producto in categoria.Productos)
            {
                producto.Categoria = null;
            }

            return categoria;
        }
    }
}
