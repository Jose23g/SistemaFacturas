using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    class Identificacion
    {
        public int Tipo { get; set; }
        [Key]
        public string Identificacion1 { get; set; }
    }
}
