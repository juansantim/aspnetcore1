using RegistroEstudiantes.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegistroEstudiantes.Data
{
    public interface IMateriaService
    {
        IList<Materia> GetAll();
    }

    public class inMemoryMateriasService : IMateriaService
    {
        IList<Materia> materias;

        public inMemoryMateriasService()
        {
            this.materias = new List<Materia>() 
            {
                new Materia { Id = 1, Codigo = "01", Area = Area.Informatica, Disponible = true, Nombre = "introduccion a la programacion" },
                new Materia { Id = 2, Codigo = "02", Area = Area.Informatica, Disponible = true, Nombre = "Programacion 1" },
                new Materia { Id = 3, Codigo = "03", Area = Area.Informatica, Disponible = true, Nombre = "Programacion 2" },
                new Materia { Id = 4, Codigo = "04", Area = Area.Informatica, Disponible = true, Nombre = "Ingenieria de Sofware" },

            };

        }

        public IList<Materia> GetAll()
        {
            return materias.OrderBy(m => m.Nombre).ToList();
        }
    }
}
