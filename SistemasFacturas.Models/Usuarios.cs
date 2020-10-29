using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
