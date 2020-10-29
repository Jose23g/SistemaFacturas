using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    class Telefonos
    {
        [Key]
        public int Identificacion { get; set; }
        public int Telefono { get; set; }
    }
}
