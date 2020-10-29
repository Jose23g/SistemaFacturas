using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Detalle
    {
        [Key]
        public int Cod_detalle { get; set; }
        public int Cod_producto { get; set; }
        public int Cod_Factura { get; set; }
        public int Cantidad { get; set; }
       

    }
}
