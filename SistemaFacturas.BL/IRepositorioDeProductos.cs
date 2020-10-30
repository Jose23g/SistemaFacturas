using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.BL
{
    public interface IRepositorioDeProductos
    {
        List<Producto> ListaDeProductos();
        List<Categorias> ListaDeCategoria();
        void AgregarProductos(Producto producto);
        void DetalleDeProducto(int ID);
        void ModificarProducto(Producto producto);
        public List<Producto> BuscarProducto(string nombre);

        Producto ObtenerProductoPorId(int id);
    }
}
