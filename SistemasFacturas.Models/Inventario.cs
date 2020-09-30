using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Inventario
    {
        [Key]
        public int Cod_inventario { get; set; }
        [Key]
        public int Cod_producto { get; set; }
        public int Cantidad { get; set; }
    }
}
