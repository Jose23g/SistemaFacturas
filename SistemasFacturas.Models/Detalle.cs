using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
    class Detalle
    {
        public int Cod_detalle { get; set; }
        public int Cod_producto { get; set; }
        public int Cod_Factura { get; set; }
        public int Cantidad { get; set; }

    }
}
