using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Persona
    {
        [Key]
        public int Identificacion { get; set; }
        public int Tipo { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public int Id_pais { get; set; }
        public int Id_provincia { get; set; }
        public int Id_canton { get; set; }
        public int Id_distrito { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
    }
}
