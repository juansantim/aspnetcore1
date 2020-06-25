using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Model;
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

    }
}
