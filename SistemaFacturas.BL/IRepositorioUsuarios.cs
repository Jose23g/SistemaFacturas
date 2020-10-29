using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturas.BL
{
    public interface IRepositorioUsuarios
    {
       
        public IEnumerable<Usuarios> GetUsuarios();
    }
}
