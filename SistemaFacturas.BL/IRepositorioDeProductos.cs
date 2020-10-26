using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturas.BL
{
   public interface IRepositorioDeProductos
    {
        List<Producto> ListaDeProductos();
        List<Categorias> ListaDeCategoria();
        void AgregarProductos(Producto producto);
        void DetalleDeProducto(int ID);
        void ModificarProducto(Producto producto);

    }
}
