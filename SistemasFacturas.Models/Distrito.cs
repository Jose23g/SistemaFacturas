using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Distrito
    {
        
        public int Id_pais { get; set; }
       
        public int Id_provincia { get; set; }
       
        public int Id_canton { get; set; }
        [Key]
        public int Id_distrito { get; set; }
        public string Nombre_distrito { get; set; }
    }
}
