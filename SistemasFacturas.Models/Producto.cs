using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemasFacturas.Models
{
    public class Producto
    {
        [Key]
        public int Cod_producto { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public int Cod_categoria { get; set; }

        [NotMapped]
        public int Cantidad { get; set; }

        [NotMapped]
        public int CantidadSelecionada { get; set; }
    }
}
