using System;
using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    class Reporte
    {
        [Key]
        public int Cod_reporte { get; set; }
        [Key]
        public int Cod_factura { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public double TotalCierre { get; set; }
    }
}
