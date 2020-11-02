using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.BL
{
    public interface IRepositorioDeProductos
    {
        List<Producto> ListaDeProductos();
        List<Categorias> ListaDeCategoria();
        void AgregarProductos(Producto producto);
        Producto ObtenerProducto(int ID);
        void ModificarProducto(Producto producto);
        public List<Producto> BuscarProducto(string nombre);
        Inventario aumentarCantidad(int codProducto, int cantidad);
        Inventario disminuirCantidad(int codProducto, int cantidad);
    }
}
