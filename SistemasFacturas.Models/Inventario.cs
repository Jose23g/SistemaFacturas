using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Inventario
    {
        [Key]
        public int Cod_inventario { get; set; }

        public int Cod_producto { get; set; }
        public int Cantidad { get; set; }
    }
}
