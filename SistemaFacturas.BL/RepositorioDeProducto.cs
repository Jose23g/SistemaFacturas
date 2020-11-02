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

            Producto nuevoproducto = producto;
            nuevoproducto.Cod_producto = producto.Cod_producto;
            nuevoproducto.Cantidad = producto.Cantidad;

            ContextoBaseDeDatos.Producto.Add(nuevoproducto);
            ContextoBaseDeDatos.SaveChanges();

            AgregarInventario(nuevoproducto.Cod_producto, nuevoproducto.Cantidad);
        }
     public void AgregarInventario(int codP, int cantidad)
            {
            Inventario inventario = new Inventario();
            inventario.Cod_producto = codP;
            inventario.Cantidad = cantidad;
            ContextoBaseDeDatos.Inventario.Add(inventario);
            ContextoBaseDeDatos.SaveChanges();
        }

        public void DetalleDeProducto(int ID)
        {
            var producto = ContextoBaseDeDatos.Producto.Find(ID);
            return producto;
           
        }

        public List<Categorias> ListaDeCategoria()
        {
            List<Categorias> listaCategoria;
            listaCategoria = ContextoBaseDeDatos.Categoria.ToList();

            return listaCategoria;
        }

        public List<Producto> ListaDeProductos()
        {
            List<Inventario> Listainventarios;
            Listainventarios = ContextoBaseDeDatos.Inventario.ToList();

            List<Producto> listaProducto;
            listaProducto = ContextoBaseDeDatos.Producto.ToList();

           foreach (var item in listaProducto)
            {
                foreach (var inventario in Listainventarios)
                {
                    if (item.Cod_producto == inventario.Cod_producto)
                    {
                        item.Cantidad = inventario.Cantidad;
                    }

                }

                                }

            return listaProducto;
        }

       public List<Producto> BuscarProducto(string nombre)
        {
            var producto = new List<Producto>();
            producto = ContextoBaseDeDatos.Producto.Where(x => x.Nombre.Contains(nombre)).ToList();
            return producto;
        }
    }
}
