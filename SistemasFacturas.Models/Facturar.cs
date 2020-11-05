using System.Collections.Generic;

namespace SistemasFacturas.Models
{
    public class Facturar
    {
        public Factura Factura { get; set; }
        public Persona Persona { get; set; }
        public List<Detalle> Detalle { get; set; }
        public List<Producto> producto { get; set; }

    }
}
