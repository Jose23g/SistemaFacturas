using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemasFacturas.Models
{
    public class Factura
    {

        [Key]
        public int Cod_factura { get; set; }     
        public DateTime FechaEmision { get; set; }
        [Required]
        public string NombreComersial { get; set; }
        public int Identificacion { get; set; }     
        public int Cod_metodo { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Monto_total { get; set; }
        public decimal MontoDescuento { get; set; }
        public int Impuesto { get; set; }
        public int Descuento { get; set; }
        public int Consecutivo { get; set; }
        public int Clave { get; set; }

    }
}
