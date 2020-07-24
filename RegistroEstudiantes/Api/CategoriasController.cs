using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Dto;
using RegistroEstudiantes.Model;
using RegistroEstudiantes.Model.Cafeteria;

namespace RegistroEstudiantes.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly RegistroEstudiantesContext db;
        private readonly IHtmlHelper helper;

        public CategoriasController(RegistroEstudiantesContext db, IHtmlHelper helper)
        {
            this.db = db;
            this.helper = helper;
        }

        [Route("GetCategoria")]
        public Categoria GetCategoria(int Id) 
        {
            var categoria = db.Categorias.Include(c => c.Productos).SingleOrDefault(c => c.Id == Id);

            foreach (var producto in categoria.Productos)
            {
                producto.Visible = true;
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

                    if (!prod.Visible)
                    {
                        db.Productos.Remove(prod);
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

        [Route("GetAreas")]
        public List<DtoSelectItem> GetAreas() 
        {
           var areas =  helper.GetEnumSelectList<Area>();

            return areas.Select(a => new DtoSelectItem
            {
                Id = int.Parse(a.Value),
                Nombre = a.Text
            }).ToList();
        }
    }
}
