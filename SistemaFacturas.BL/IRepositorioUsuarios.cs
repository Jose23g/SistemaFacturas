using SistemasFacturas.Models;
using System.Collections.Generic;

namespace SistemaFacturas.BL
{
    public interface IRepositorioUsuarios
    {

        public IEnumerable<Usuarios> GetUsuarios();
    }
}
