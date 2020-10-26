
using Microsoft.AspNetCore.Identity;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturas.BL
{
    public interface IRepositorioFactura
    {
        void AgregarFactura();
        List<MedotoPago> MetodoPagos();
        void obtenerUsuario(UserManager<IdentityUser> userManager);
        Facturar postFactura();
        List<string> buscar(string term);
    }
}
