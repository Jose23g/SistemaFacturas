using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Canton
    {
        [Key]
        public int Id_pais { get; set; }
        [Key]
        public int Id_provincia { get; set; }
        [Key]
        public int Id_canton { get; set; }
        public string Nombre_canton { get; set; }
    }
}
