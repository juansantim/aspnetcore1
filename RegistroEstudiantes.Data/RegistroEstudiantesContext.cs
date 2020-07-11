using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Model;
using RegistroEstudiantes.Model.Papeleria;
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
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Categoria>().HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<DetalleFactura>().Property(c => c.Cantidad).HasColumnType("Decimal(10,2)");
            modelBuilder.Entity<DetalleFactura>().Property(c => c.Costo).HasColumnType("Decimal(10,2)");
            modelBuilder.Entity<DetalleFactura>().Property(c => c.Total).HasColumnType("Decimal(10,2)");
        }

    }
}
