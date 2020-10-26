using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemasFacturas.Models
{
   public class Categorias
    {
        [Key]
        public int Cod_categoria { get; set; }
        public string Categoria { get; set; }
    }
}
