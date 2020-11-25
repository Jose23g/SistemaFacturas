using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
   public class ModeloReportes
    {
        public Reporte Reporte { get; set; }
        public List<Factura> ListaFacturas { get; set; }
    }
}
