using System.ComponentModel.DataAnnotations;

namespace SistemasFacturas.Models
{
    public class Persona
    {
        [Key, Display(Name = "Identificación"), Required]
        public int Identificacion { get; set; }
        [Display(Name = "Tipo  de identificación"), Required]
        public int Tipo { get; set; }

        [Display(Name = "Nombre"), Required]
        public string Nombre { get; set; }
        [Display(Name = "Apellido"), Required]
        public string Apellido1 { get; set; }

        [Display(Name = "Correo electrónico"), DataType(DataType.EmailAddress), Required]
        public string Correo { get; set; }

        [Display(Name = "Teléfono"), DataType(DataType.PhoneNumber), Required]
        public string Telefono { get; set; }

        [Display(Name = "País"), Required]
        public string Pais { get; set; }

        [Display(Name = "Provincia"), Required]
        public string Provincia { get; set; }

        [Display(Name = "Cantón"), Required]
        public string Canton { get; set; }

        [Display(Name = "Distrito"), Required]
        public string Distrito { get; set; }



    }
}
