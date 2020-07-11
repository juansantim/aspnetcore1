using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroEstudiantes.Model.Papeleria
{
    public class DetalleFactura
    {
        public int Id { get; set; }

        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
    }
}
