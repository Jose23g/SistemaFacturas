using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemasFacturas.Models
{
    public class Reporte
    {
        [Key]
        public int CodReporte { get; set; }
        public DateTime FechaInicio { get; set; }

        [NotMapped]
        public int Cod_factura { get; set; }
        public DateTime FechaCierre { get; set; }
        public decimal TotalCierre { get; set; }
       
       
    }
}
