using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Factura
    {
        [Key]
        public int Cod_factura { get; set; }
        public DateTime FechaEision { get; set; }
        public string NombreComercial { get; set; }
        public int Identificacion { get; set; }
        public double Subtotal { get; set; }
        public double Monto_total { get; set; }
        public double MontoDescuento { get; set; }
        public double Impuesto { get; set; }
        public int Cod_metodo { get; set; }
    }
}
