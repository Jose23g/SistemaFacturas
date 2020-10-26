
using Microsoft.AspNetCore.Identity;
using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaFacturas.BL
{
   public class RepositorioFactura: IRepositorioFactura
    {
        private ApplicationDbContext ContextoBaseDeDatos;
        public RepositorioFactura(ApplicationDbContext contexto)
        {
            ContextoBaseDeDatos = contexto;
        }

        public void AgregarFactura()
        {
            throw new NotImplementedException();
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

        public Facturar postFactura()
        {
            Facturar factura = new Facturar();
            try
            {
              
                return factura;
            }
            catch(Exception ex)
            {
                return factura;
            }
           
        }

        public List<string> buscar(string term)
        {
             var posttible = ContextoBaseDeDatos.Producto.Where(p => p.Nombre.Contains(term))
                .Select(p => p.Nombre).ToList();
            return posttible;
        }
    }
}
