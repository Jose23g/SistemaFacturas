using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
    class Producto
    {
        public int Cod_producto { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public double Precio { get; set; }
        public int Cod_categoría { get; set; }
    }
}
