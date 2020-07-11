using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Model.Papeleria
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public List<DetalleFactura> Productos { get; set; }
    }
}
