
using Microsoft.AspNetCore.Identity;
using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.BL
{
    public interface IRepositorioFactura
    {
        void AgregarFactura(Facturar facturar);
        void AgregarDetalles(List<Detalle> detalles, int codFactura);
        List<MedotoPago> MetodoPagos();
        void obtenerUsuario(UserManager<IdentityUser> userManager);
        void setEncabezado(Factura factura);
        public List<Producto> bus_atr(string dato_bus, int cantidad);
        public int Disponible(int codProducto, int cantidad);
        public Producto producto(string CodProducto);
    }
}
