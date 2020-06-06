using RegistroEstudiantes.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegistroEstudiantes.Data
{
    public interface IMateriaService
    {
        IList<Materia> GetMateriasPorNombre(string texto);
        Materia GetMateriaPorId(int Id);
    }

    public class inMemoryMateriasService : IMateriaService
    {
        IList<Materia> materias;

        public inMemoryMateriasService()
        {
            this.materias = new List<Materia>() 
            {
                new Materia { Id = 1, Codigo = "01", Area = Area.Informatica, Disponible = true, Nombre = "Introduccion a la programacion", Objetivos = "Adquirir los elementos basicos para entender los fundamentos de la programacion" },
                new Materia { Id = 2, Codigo = "02", Area = Area.Informatica, Disponible = true, Nombre = "Programacion 1", Objetivos = "esto es el objetivo" },
                new Materia { Id = 3, Codigo = "03", Area = Area.Informatica, Disponible = true, Nombre = "Programacion 2", Objetivos = "esto es el objetivo"  },
                new Materia { Id = 4, Codigo = "04", Area = Area.Informatica, Disponible = true, Nombre = "Ingenieria de Software", Objetivos = "esto es el objetivo"  },

            };

        }

        public Materia GetMateriaPorId(int Id)
        {
            return this.materias.SingleOrDefault(d => d.Id == Id);
        }

        public IList<Materia> GetMateriasPorNombre(string texto)
        {
            if (!string.IsNullOrEmpty(texto)) 
            {
                texto = texto.ToLower();
            }
          
            return materias.Where(m => string.IsNullOrEmpty(texto) || m.Nombre.ToLower().Contains(texto)).OrderBy(m => m.Nombre).ToList();
        }
    }
}
