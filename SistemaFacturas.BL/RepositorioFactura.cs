
using Microsoft.AspNetCore.Identity;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SistemaFacturas.BL
{
    public class RepositorioFactura : IRepositorioFactura
    {
        private ApplicationDbContext ContextoBaseDeDatos;
        public RepositorioFactura(ApplicationDbContext contexto)
        {
            ContextoBaseDeDatos = contexto;
        }

        public void AgregarFactura(Facturar facturar)
        {
            Factura nuevaFactura = facturar.Factura;
            ContextoBaseDeDatos.Factura.Add(nuevaFactura);
            ContextoBaseDeDatos.SaveChanges();

            AgregarDetalles(facturar.Detalle, nuevaFactura.Cod_factura);
            reporte(facturar.Factura);

        }
        public void AgregarDetalles(List<Detalle> detalles, int codFactura)
        {
            foreach (var item in detalles)
            {
                item.Cod_Factura = codFactura;
                ContextoBaseDeDatos.Detalle.Add(item);
            }
            ContextoBaseDeDatos.SaveChanges();
        }

        public void reporte(Factura nuevaFactura)
        {
            Reporte nuevoReporte = new Reporte();
            nuevoReporte.Cod_factura = nuevaFactura.Cod_factura;
            nuevoReporte.FechaInicio = nuevaFactura.FechaEmision;
            nuevoReporte.TotalCierre = nuevaFactura.Subtotal;
            
           
            var resultado = (from c in ContextoBaseDeDatos.Reporte
                             where c.FechaInicio == nuevaFactura.FechaEmision
                             select c).FirstOrDefault();

            if (resultado != null)
            {
                ContextoBaseDeDatos.Update(nuevoReporte);
                ContextoBaseDeDatos.SaveChanges();
            }
            else
            {
                ContextoBaseDeDatos.Add(nuevoReporte);
                ContextoBaseDeDatos.SaveChanges();
            }

        }

        public List<Factura> facturas()
        {
            List<Factura> listaFactura = ContextoBaseDeDatos.Factura.ToList();
            return listaFactura;
        }

        public List<Reporte> reportes()
        {
        
            List<Reporte> listaReporte = ContextoBaseDeDatos.Reporte.ToList();
           
            return listaReporte;
        }

        public void XML(Facturar facturar)
        {
            XmlDocument documento = new XmlDocument();
            XmlNode root = documento.CreateElement("FacturaElectronica");
            documento.AppendChild(root);

            XmlNode contactNode = documento.CreateElement("Consecutivo");
            contactNode.InnerText = "000011000";
            root.AppendChild(contactNode);

            documento.Save("JOSEFACURA.xml");


        }

        public List<MedotoPago> MetodoPagos()
        {
            List<MedotoPago> listaMetodos;
            listaMetodos = ContextoBaseDeDatos.MetodoPago.ToList();
            return listaMetodos;
        }

        public void AgregarCliente(Persona persona)
        {

            ContextoBaseDeDatos.Persona.Add(persona);
            ContextoBaseDeDatos.SaveChanges();

        }

        public List<Persona> ListaClientes()
        {
            List<Persona> listaclientes;
            listaclientes = ContextoBaseDeDatos.Persona.ToList();
            return listaclientes;
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
                        item.CantidadSelecionada = cantidad;
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
            int disponible = 0;
            var inventario = new List<Inventario>();

            inventario = (from c in ContextoBaseDeDatos.Inventario where c.Cod_producto == codProducto select c).ToList();

            foreach (var item in inventario)
            {
                if (item.Cod_producto == codProducto)
                {
                    if (item.Cantidad > cantidadSolicitada)
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

        public List<Identificaciones> TipoIdentificacion()
        {
            
                List<Identificaciones> listaIdentifaciones;
                listaIdentifaciones = ContextoBaseDeDatos.Identificaciones.ToList();
                return listaIdentifaciones;
            
        }
    }
}
