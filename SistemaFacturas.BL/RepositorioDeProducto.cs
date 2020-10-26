using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaFacturas.BL
{
   public class RepositorioDeProducto : IRepositorioDeProductos
    {
        private ApplicationDbContext ContextoBaseDeDatos;
        public RepositorioDeProducto(ApplicationDbContext contexto)
        {
            ContextoBaseDeDatos = contexto;
        }

        public void AgregarProductos(Producto producto)
        {
            ContextoBaseDeDatos.Producto.Add(producto);
            ContextoBaseDeDatos.SaveChanges();
        }

        public void DetalleDeProducto(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Categorias> ListaDeCategoria()
        {
            List<Categorias> listaCategoria;
            listaCategoria = ContextoBaseDeDatos.Categoria.ToList();

            return listaCategoria;
        }

        public List<Producto> ListaDeProductos()
        {
            List<Producto> listaProducto;
            listaProducto = ContextoBaseDeDatos.Producto.ToList();

            return listaProducto;
        }

        public void ModificarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
