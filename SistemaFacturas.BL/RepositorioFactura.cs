
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
        public List<Producto> bus_atr(string dato_bus, int cantidad)
        {
            var autores = new List<Producto>();
            
            try
            {
                autores = (from c in ContextoBaseDeDatos.Producto
                           where c.Nombre == dato_bus
                           select c).ToList();
                
                foreach (var item in autores)
                {
                    if (item.Nombre.Equals(dato_bus))
                    {
                        item.Cantidad = Disponible(item.Cod_producto, cantidad);
                    }
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            return autores;
        }
        public int Disponible(int codProducto, int cantidadSolicitada)
        {
            int disponible =0;
            var inventario = new List<Inventario>();

            inventario = (from c in ContextoBaseDeDatos.Inventario where c.Cod_producto == codProducto select c).ToList();

            foreach (var item in inventario)
            {
                if (item.Cod_producto == codProducto)
                {
                    if(item.Cantidad > cantidadSolicitada)
                    {
                        disponible = item.Cantidad;
                    }
                    else
                    {
                        disponible = item.Cantidad;
                    }
                }             
            }
            
            return disponible;
        }
        public Producto producto(string CodProducto)
        {
            return ContextoBaseDeDatos.Producto.Find(int.Parse(CodProducto));
        }
    }
}
