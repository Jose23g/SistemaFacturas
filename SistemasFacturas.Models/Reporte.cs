using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
    class Reporte
    {
        public int Cod_reporte { get; set; }
        public int Cod_factura { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public double TotalCierre { get; set; }
    }
}
