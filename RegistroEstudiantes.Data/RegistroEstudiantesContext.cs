using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Model;
using RegistroEstudiantes.Model.Cafeteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Data
{
    //CodeFirst******/
    public class RegistroEstudiantesContext : DbContext
    {
        public RegistroEstudiantesContext(DbContextOptions<RegistroEstudiantesContext> options) : 
            base(options)
        {

        }

        public DbSet<Materia> Materias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Categoria>().HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);


            modelBuilder.Entity<Categoria>().Property(c => c.Nombre).HasMaxLength(50);
            modelBuilder.Entity<Categoria>().Property(c => c.Nombre).IsRequired(true);            
        }

    }
}
