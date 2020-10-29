using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Categorias
    {
        [Key]
        public int Cod_categoria { get; set; }
        public string Categoria { get; set; }
    }
}
