using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasFacturas.Models;

namespace SistemaFacturas.DA
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<MedotoPago> MetodoPago { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
