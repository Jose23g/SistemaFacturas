using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    public class MedotoPago
    {
        [Key]
        public int Cod_metodo { get; set; }
        public string Metodo_de_pago { get; set; }
    }
}
