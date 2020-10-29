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
        public string NombreComercial { get; set; }
        public int Identificacion { get; set; }     
        public int Cod_metodo { get; set; }
        public string NumeroFactura { get; set; }
        public double Subtotal { get; set; }
        public double Monto_total { get; set; }
        public double MontoDescuento { get; set; }
        public double Impuesto { get; set; }
        public int Descuento { get; set; }


    }
}
