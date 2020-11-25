using SistemaFacturas.BL;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasFacturas.MockPruebas
{
    class MockRepositorioProducto : IRepositorioDeProductos
    {
        List<Producto> listaproductos = new List<Producto>();

        public void AgregarProductos(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Inventario aumentarCantidad(int codProducto, int cantidad)
        {
            throw new NotImplementedException();
        }

        public List<Producto> BuscarProducto(string nombre)
        {
            throw new NotImplementedException();
        }

        public Inventario disminuirCantidad(int codProducto, int cantidad)
        {
            throw new NotImplementedException();
        }

        public List<Categorias> ListaDeCategoria()
        {
            throw new NotImplementedException();
        }

        public List<Producto> ListaDeProductos()
        {
            throw new NotImplementedException();
        }

        public void ModificarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Producto ObtenerProductoPorId(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
