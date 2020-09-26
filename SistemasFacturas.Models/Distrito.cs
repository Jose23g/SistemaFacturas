using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
    class Distrito
    {
        public int Id_pais { get; set; }
        public int Id_provincia { get; set; }
        public int Id_canton { get; set; }
        public int Id_distrito { get; set; }
        public string Nombre_distrito { get; set; }
    }
}
