using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Identificacion
    {
        public int Tipo { get; set; }
        [Key]
        public string Identificacion1 { get; set; }
    }
}
