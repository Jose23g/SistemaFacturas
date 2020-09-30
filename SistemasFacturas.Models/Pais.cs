using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Pais
    {
        [Key]
        public int Id_pais { get; set; }
        public string Nombre_Pais { get; set; }
    }
}
