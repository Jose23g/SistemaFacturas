using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasFacturas.Models;

namespace SistemaFacturas.DA
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Persona> Persona { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
