using System.ComponentModel;

namespace SistemasFacturas.Models
{
    public class Usuarios
    {

        public string ID { get; set; }
        [DisplayName("Nombre")]
        public string Username { get; set; }
        [DisplayName("Rol")]
        public string Roles { get; set; }
    }
}
