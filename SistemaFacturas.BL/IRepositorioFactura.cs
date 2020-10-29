﻿
using Microsoft.AspNetCore.Identity;
using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.BL
{
    public interface IRepositorioFactura
    {
        void AgregarFactura(Facturar facturar, List<string> codigos);
        List<MedotoPago> MetodoPagos();
        void obtenerUsuario(UserManager<IdentityUser> userManager);
        void setEncabezado(Factura factura);
        public List<Producto> bus_atr(string dato_bus);
        public bool Disponible(int codProducto);
    }
}