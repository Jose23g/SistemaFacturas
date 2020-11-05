using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Canton
    {
       
        public int Id_pais { get; set; }
       
        public int Id_provincia { get; set; }
        [Key]
        public int Id_canton { get; set; }
        public string Nombre_canton { get; set; }
    }
}
