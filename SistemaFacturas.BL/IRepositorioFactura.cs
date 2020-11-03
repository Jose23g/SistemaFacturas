
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
        List<Identificaciones> TipoIdentificacion();
        void obtenerUsuario(UserManager<IdentityUser> userManager);
        void setEncabezado(Factura factura);
        public List<Producto> bus_atr(string dato_bus, int cantidad);
        public int Disponible(int codProducto, int cantidad);
        public Producto producto(string CodProducto);
        void AgregarCliente(Persona persona);
        public List<Persona> ListaClientes();

        void XML(Facturar facturar);
        void reporte(Factura nuevaFactura);
        List<Reporte> reportes();
        List<Factura> facturas();
    }
}
