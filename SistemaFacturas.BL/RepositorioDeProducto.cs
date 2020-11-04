using SistemaFacturas.DA;
using SistemasFacturas.Models;
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

        public Producto DetalleDeProducto(int ID)
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


        public Inventario disminuirCantidad(int codProducto, int cantidad)
        {
            Inventario inventario = new Inventario();
            inventario = (from i in ContextoBaseDeDatos.Inventario
                          where i.Cod_producto == codProducto
                          select i).FirstOrDefault();
            inventario.Cantidad -= cantidad;
            ContextoBaseDeDatos.Inventario.Update(inventario);
            ContextoBaseDeDatos.SaveChanges();

            return inventario;
        }

        public Inventario aumentarCantidad(int codProducto, int cantidad)
        {
            Inventario inventario = new Inventario();
            inventario = (from i in ContextoBaseDeDatos.Inventario
                          where i.Cod_producto == codProducto
                          select i).FirstOrDefault();
            inventario.Cantidad += cantidad;
            ContextoBaseDeDatos.Inventario.Update(inventario);
            ContextoBaseDeDatos.SaveChanges();

            return inventario;
        }
    }
}
