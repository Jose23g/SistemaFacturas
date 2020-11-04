using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Distrito
    {
        [Key]
        public int Id_pais { get; set; }
        [Key]
        public int Id_provincia { get; set; }
        [Key]
        public int Id_canton { get; set; }
        [Key]
        public int Id_distrito { get; set; }
        public string Nombre_distrito { get; set; }
    }
}
