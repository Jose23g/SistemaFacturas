using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Provincia
    {
        [Key]
        public int Id_pais { get; set; }
        [Key]
        public int Id_provincia { get; set; }
        public string Nombre_provincia { get; set; }
    }
}
