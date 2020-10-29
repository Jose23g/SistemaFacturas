
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFacturas.BL
{
    public class RepositorioFactura : IRepositorioFactura
    {
        private ApplicationDbContext ContextoBaseDeDatos;
        public RepositorioFactura(ApplicationDbContext contexto)
        {
            ContextoBaseDeDatos = contexto;
        }

        public void AgregarFactura(Facturar facturar, List<string> codigos)
        {
            Factura factura = new Factura();
            Producto producto = new Producto();
            Detalle detalle = new Detalle();

            facturar.Factura = factura;
            
        }

        public List<MedotoPago> MetodoPagos()
        {
            List<MedotoPago> listaMetodos;
            listaMetodos = ContextoBaseDeDatos.MetodoPago.ToList();
            return listaMetodos;
        }

        public void obtenerUsuario(UserManager<IdentityUser> userManager)
        {


        }

        public void setEncabezado(Factura factura)
        {
            ContextoBaseDeDatos.Factura.Add(factura);
            ContextoBaseDeDatos.SaveChanges();
        }

        // Busqueda de Producto
        public List<Producto> bus_atr(string dato_bus)
        {
            var autores = new List<Producto>();
            
            try
            {
                autores = (from c in ContextoBaseDeDatos.Producto
                           where c.Nombre == dato_bus
                           select c).ToList();

               
            }
            catch (Exception)
            {
                throw;
            }
            return autores;
        }
        public bool Disponible(int codProducto)
        {
            bool disponible= false;
            Inventario inventario = new Inventario();

            inventario = ContextoBaseDeDatos.Inventario.Where(x => x.Cod_producto.Equals(codProducto)).FirstOrDefault();
            if(inventario.Cantidad > 1)
            {
                disponible = true;
            }
            else
            {
                disponible = false;
            }

            return disponible;
        }
    }
}
