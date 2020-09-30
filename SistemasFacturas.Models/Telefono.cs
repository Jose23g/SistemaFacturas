using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Telefonos
    {
        [Key]
        public int Identificacion { get; set; }
        public int Telefono { get; set; }
    }
}
