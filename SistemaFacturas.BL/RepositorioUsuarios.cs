using SistemaFacturas.DA;
using SistemasFacturas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFacturas.BL
{
    public class RepositorioUsuarios : IRepositorioUsuarios

    {
        private ApplicationDbContext ElContextoDeBaseDeDatos;
        public RepositorioUsuarios(ApplicationDbContext contexto)
        {
            ElContextoDeBaseDeDatos = contexto;
        }

        public IEnumerable<Usuarios> GetUsuarios()
           
        {

            var resultado = (from user in ElContextoDeBaseDeDatos.Users
                             from userRol in ElContextoDeBaseDeDatos.UserRoles.Where(x => x.UserId == user.Id).DefaultIfEmpty()
                             from ar in ElContextoDeBaseDeDatos.Roles.Where(x => x.Id == userRol.RoleId).DefaultIfEmpty()
                             select new Usuarios
                             {
                                 Username = user.Email,
                                 Roles = ar.Name

                             }).ToList();

            return resultado;//resultado;
        }

     
    }
}
