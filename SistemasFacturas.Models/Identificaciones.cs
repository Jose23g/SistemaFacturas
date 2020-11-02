using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Identificaciones
    {
        public int Tipo { get; set; }
        [Key]
        public string Identificacion { get; set; }

       
    }
}
