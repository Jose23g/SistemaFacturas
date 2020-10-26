
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.Models
{
    public class Facturar
    {
        public Factura? factura { get; set; }

        public List<Detalle> detalle { get; set; }
        
        public Producto producto { get; set; }

    }
}
