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

        public Producto ObtenerProducto(int ID)
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
            List<Producto> listaProducto;
            listaProducto = ContextoBaseDeDatos.Producto.ToList();

            return listaProducto;
        }

        public void ModificarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

       public List<Producto> BuscarProducto(string nombre)
        {
            var producto = new List<Producto>();
            producto = ContextoBaseDeDatos.Producto.Where(x => x.Nombre.Contains(nombre)).ToList();
            return producto;
        }


        public Inventario aumentarCantidad(int codProducto, int cantidad)
        {
            Inventario inventario = new Inventario();
            
            inventario = (from i in ContextoBaseDeDatos.Inventario
                          where i.Cod_producto == codProducto
                          select i).FirstOrDefault();
            
            if(inventario.Cantidad != 0)
            {
                inventario.Cantidad += cantidad;
                ContextoBaseDeDatos.Inventario.Update(inventario);
                ContextoBaseDeDatos.SaveChanges();
            }

            return inventario;
        }
        public Inventario disminuirCantidad(int codProducto, int cantidad)
        {
            Inventario inventario = new Inventario();
            inventario = (from i in ContextoBaseDeDatos.Inventario
                          where i.Cod_producto == codProducto
                          select i).FirstOrDefault();
            try
            {
                if (inventario.Cantidad != 0)
                {
                    inventario.Cantidad -= cantidad;
                    ContextoBaseDeDatos.Inventario.Update(inventario);
                    ContextoBaseDeDatos.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
            

            return inventario;
        }
    }
}
