using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
    class Categoria
    {
        [Key]
        public int Cod_categoria { get; set; }
        public string Categorias { get; set; }
    }
}
