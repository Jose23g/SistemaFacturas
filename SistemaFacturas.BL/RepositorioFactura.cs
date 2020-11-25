
using Microsoft.AspNetCore.Identity;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace SistemaFacturas.BL
{
    public class RepositorioFactura : IRepositorioFactura
    {
        private ApplicationDbContext ContextoBaseDeDatos;
        public RepositorioFactura(ApplicationDbContext contexto)
        {
            ContextoBaseDeDatos = contexto;
        }
        public RepositorioFactura()
        {

        }
        public void AgregarFactura(Facturar facturar)
        {
           
            Factura nuevaFactura = facturar.Factura;
            nuevaFactura.Impuesto = 13;
            nuevaFactura.Clave = GenerarClave(nuevaFactura.Consecutivo);
            ContextoBaseDeDatos.Factura.Add(nuevaFactura);
            ContextoBaseDeDatos.SaveChanges();

            AgregarDetalles(facturar.Detalle, nuevaFactura.Cod_factura);
            reporte(facturar.Factura);
            XML(facturar);

        }

        public String GenerarClave(String consecutivo)
        {
            try
            {
                return ("506" + DateTime.Now.ToString("ddMMyy") + "00" + "12345678910" + consecutivo + "1" + GenerarCodigoSeguridad());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private String GenerarCodigoSeguridad()
        {
            Random GeneradorRandom = new Random();
            String caracteres = "1234567890";
            int longitud = caracteres.Length;
            int largocodigo = 8;
            char caracter;
            String CodigoSeguridad = "";
            for (int i = 0; i < largocodigo; i++)
            {
                caracter = caracteres[GeneradorRandom.Next(longitud)];
                CodigoSeguridad += caracter.ToString();
            }
            return CodigoSeguridad;
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
            Reporte nuevoReporte = new Reporte
            {
                Cod_factura = nuevaFactura.Cod_factura,
                FechaInicio = nuevaFactura.FechaEmision,
                TotalCierre = nuevaFactura.Subtotal
            };


            Reporte reporte = ContextoBaseDeDatos.Reporte.Where(x => x.FechaInicio == nuevoReporte.FechaInicio).FirstOrDefault();

            if (reporte != null)
            {
                reporte.TotalCierre += nuevoReporte.TotalCierre;
                ContextoBaseDeDatos.Reporte.Update(reporte);
            }
            else
            {
                ContextoBaseDeDatos.Add(nuevoReporte);
            }

            ContextoBaseDeDatos.SaveChanges();
           
        }

        public List<Factura> facturas()
        {
            List<Factura> listaFactura = ContextoBaseDeDatos.Factura.ToList();
            return listaFactura;
        }

        public List<Reporte> reportes()
        {

            List<Reporte> listaReporte = ContextoBaseDeDatos.Reporte.ToList();

            //Reporte reporte = listaReporte.Select;

            return listaReporte;
        }

        public void XML(Facturar facturar)
        {


            XDocument doc = new XDocument(
                new XDeclaration("1.0", "gb2312", string.Empty),
                new XElement("FacturaElectronica",
                    new XElement("Consecutivo", facturar.Factura.Consecutivo),
                    new XElement("Clave", facturar.Factura.Clave),
                    new XElement("FechaEmision", facturar.Factura.FechaEmision.ToString()),
                    new XElement("Emisor",
                        new XElement("Nombre", facturar.Factura.NombreComersial),
                        new XElement("Identificacion",
                            new XElement("Tipo", "01"),
                            new XElement("Numero", "1234567890"),
                            new XElement("NombreComercial", facturar.Factura.NombreComersial)
                            )),
                    new XElement("Receptor",
                    new XElement("Nombre", facturar.Persona.Nombre),
                    new XElement("Identificacion",
                        new XElement("Tipo", facturar.Persona.Tipo),
                        new XElement("Numero", facturar.Persona.Identificacion)),
                    new XElement("Telefono", facturar.Persona.Telefono)),
                    new XElement("CondicionVenta", "**PONER CONDICION DE VENTA**"),
                    new XElement("MedioPago", facturar.Factura.Cod_metodo.ToString()),
                    new XElement("Impuesto", facturar.Factura.Impuesto),
                    new XElement("Total", facturar.Factura.Monto_total.ToString()),
                    new XElement("SubTotal", facturar.Factura.Subtotal.ToString()),
                    new XElement("DetalleServicio", facturar.producto.Select(producto =>
                        new XElement("Producto",
                                new XElement("NombreProducto", producto.Nombre),
                                new XElement("Detalle", producto.Nombre),
                                new XElement("PrecioUnitario", producto.Precio),
                                new XElement("Cantidad", producto.CantidadSelecionada),
                                new XElement("Subtotal", "**AGREGAR UN SUBTOTAL**"))))));

            doc.Save(@"C:\Users\adria\Desktop\file.xml");

        }

        public string Consecutivo()
        {
            string consecutivo = "0010000101";
    
            List<Factura> facturas = ContextoBaseDeDatos.Factura.ToList();
            long cantidad = facturas.Count() + 1;
            string consecutivoFactura = consecutivo;
            string numerofactura = "";
            if (cantidad < 999999999)
            {
                long faltante = (10 - cantidad.ToString().Length);
                 numerofactura = cantidad.ToString();
                for (int i = 0; i < faltante; i++)
                {
                    numerofactura = String.Concat(0.ToString(), numerofactura);
                }
            }
            return consecutivoFactura + numerofactura;
        }

        public List<MedotoPago> MetodoPagos()
        {
            List<MedotoPago> listaMetodos;
            listaMetodos = ContextoBaseDeDatos.MetodoPago.ToList();
            return listaMetodos;
        }

        public bool AgregarCliente(Persona persona)
        {
            try
            {
                ContextoBaseDeDatos.Persona.Add(persona);
                ContextoBaseDeDatos.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
           

        }

        public Persona buscarPersona(int id)
        {
            Persona persona = ContextoBaseDeDatos.Persona.Find(id);
            return persona;
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
            var productos = new List<Producto>();

            try
            {
                productos = (from c in ContextoBaseDeDatos.Producto
                           where c.Nombre.Contains(dato_bus)
                           select c).ToList();

                foreach (var item in productos)
                {
                    
                        item.Cantidad = Disponible(item.Cod_producto, cantidad);
                        item.CantidadSelecionada = cantidad;
                    
                }

            }
            catch (Exception)
            {
                throw;
            }
            return productos;
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

        public List<Provincia> provincias(string IdPais)
        {
            List<Provincia> provincias = (from p in ContextoBaseDeDatos.Provincia
                                          where p.Id_pais == int.Parse(IdPais)
                                          select p).ToList();

            return provincias;
        }

        public List<Canton> cantones(String IdProvincia)
        {
            List<Canton> Canton = (from p in ContextoBaseDeDatos.Canton
                                          where p.Id_provincia == int.Parse(IdProvincia)
                                          select p).ToList();

            return Canton;
        }

        public List<Distrito> distritos(String IdCanton, String IdProvincia)
        {
            List<Distrito> distritos = (from p in ContextoBaseDeDatos.Distrito
                                   where p.Id_canton  == int.Parse(IdCanton) && p.Id_provincia == int.Parse(IdProvincia)
                                   select p).ToList();

            return distritos;
        }

       public List<Pais> listaPais()
        {
           
            return ContextoBaseDeDatos.Pais.ToList();
        }

        public List<Provincia> listaProvincia()
        {
            return ContextoBaseDeDatos.Provincia.ToList();
        }

        public List<Canton> listaCanton()
        {
            return ContextoBaseDeDatos.Canton.ToList();
        }

        public List<Distrito> listaDistito()
        {
            return ContextoBaseDeDatos.Distrito.ToList();
        }

        public ModeloReportes DetalleReporte(DateTime fechas, int id )
        {
            ModeloReportes detalles = new ModeloReportes();
            detalles.ListaFacturas = ContextoBaseDeDatos.Factura.Where(x => x.FechaEmision == fechas).ToList();
            detalles.Reporte = ContextoBaseDeDatos.Reporte.Find(id);
                
            return detalles;
        }
    }
}
