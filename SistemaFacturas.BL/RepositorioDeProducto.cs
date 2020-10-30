using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

       public List<Producto> BuscarProducto(string nombre)
        {
            var producto = new List<Producto>();
            producto = ContextoBaseDeDatos.Producto.Where(x => x.Nombre.Contains(nombre)).ToList();
            return producto;
        }

     

       

        public Producto ObtenerProductoPorId(int id)
        {
            Producto ProductoEncontrado;
            ProductoEncontrado = ContextoBaseDeDatos.Producto.Find(id);
            return ProductoEncontrado;
        }

        public void ModificarProducto(Producto producto)
        {
            Producto productoPorActualizar;
            productoPorActualizar = ObtenerProductoPorId(producto.Cod_producto);
            productoPorActualizar.Nombre = producto.Nombre;
            productoPorActualizar.Detalle = producto.Detalle;
            productoPorActualizar.Precio = producto.Precio;
            productoPorActualizar.Cod_categoria = producto.Cod_categoria;
            productoPorActualizar.Cantidad = producto.Cantidad;
            ContextoBaseDeDatos.Producto.Update(productoPorActualizar);
            ContextoBaseDeDatos.SaveChanges();
        }
    }
}
