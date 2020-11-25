using Microsoft.AspNetCore.Identity;
using SistemaFacturas.BL;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SistemaFacturas.MockPruebas
{
   public class MockRepositorioFactura : IRepositorioFactura
    {
        List<Factura> listaFactura = new List<Factura>();
        List<Persona> listaPersona = new List<Persona>();
        List<Producto> listaProducto = new List<Producto>();

        Persona persona1 = new Persona() { Identificacion = 504220984, Nombre = "Jose", Apellido1 = "Garcia", Pais = 1, Provincia = 1, Canton = 1, Distrito = 1, Correo = "garciarubiojose79@gmail.com", Telefono = "84499545", Tipo = 1 };
        Persona persona2 = new Persona() { Identificacion = 504220984, Nombre = "Jorge", Apellido1 = "Lopez", Pais = 1, Provincia =1, Canton = 1, Distrito = 1, Correo = "miguel@gmail.com", Telefono = "88294975", Tipo = 1 };
       
        
        public bool AgregarCliente(Persona persona)
        {
            try
            {
                listaPersona.Add(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void AgregarDetalles(List<Detalle> detalles, int codFactura)
        {
            throw new NotImplementedException();
        }

        public void AgregarFactura(Facturar facturar)
        {
           // bool correcto = false;
            Factura nuevaFactura = facturar.Factura;
            listaFactura.Add(nuevaFactura);
            
            AgregarDetalles(facturar.Detalle, nuevaFactura.Cod_factura);
            reporte(facturar.Factura);
           // XML(facturar);


            throw new NotImplementedException();
        }

        public Persona buscarPersona(int cedula)
        {
            listaPersona.Add(persona2);
            listaPersona.Add(persona1);
            Persona per = listaPersona.FirstOrDefault(x => x.Identificacion == cedula);
            return per;
        }

        public List<Producto> bus_atr(string dato_bus, int cantidad)
        {
            throw new NotImplementedException();
        }

        public List<Canton> cantones(string idCanton)
        {
            throw new NotImplementedException();
        }

        public string Consecutivo()
        {
            string consecutivo = "0010000101";

            List<Factura> facturas = listaFactura.ToList();
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

            public ModeloReportes DetalleReporte(DateTime fechas, int id)
        {
            throw new NotImplementedException();
        }

        public int Disponible(int codProducto, int cantidad)
        {
            throw new NotImplementedException();
        }

        public List<Distrito> distritos(string IdDistrito, string IdProvincia)
        {
            throw new NotImplementedException();
        }

        public List<Factura> facturas()
        {
            throw new NotImplementedException();
        }

        public List<Canton> listaCanton()
        {
            throw new NotImplementedException();
        }

        public List<Persona> ListaClientes()
        {
            throw new NotImplementedException();
        }

        public List<Distrito> listaDistito()
        {
            throw new NotImplementedException();
        }

        public List<Pais> listaPais()
        {
            throw new NotImplementedException();
        }

        public List<Provincia> listaProvincia()
        {
            throw new NotImplementedException();
        }

        public List<MedotoPago> MetodoPagos()
        {
            throw new NotImplementedException();
        }

        public void obtenerUsuario(UserManager<IdentityUser> userManager)
        {
            throw new NotImplementedException();
        }

        public Producto producto(string CodProducto)
        {
            throw new NotImplementedException();
        }

        public List<Provincia> provincias(string idProvincia)
        {
            throw new NotImplementedException();
        }

        public void reporte(Factura nuevaFactura)
        {
            throw new NotImplementedException();
        }

        public List<Reporte> reportes()
        {
            throw new NotImplementedException();
        }

        public void setEncabezado(Factura factura)
        {
            throw new NotImplementedException();
        }

        public List<Identificaciones> TipoIdentificacion()
        {
            throw new NotImplementedException();
        }

        public void XML(Facturar facturar)
        {
            throw new NotImplementedException();
        }
    }
}
