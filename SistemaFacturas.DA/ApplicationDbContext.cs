﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemasFacturas.Models;

namespace SistemaFacturas.DA
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Categorias> Categoria { get; set; }
        public DbSet<MedotoPago> MetodoPago { get; set; }
        public DbSet<Identificaciones> Identificaciones { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Reporte> Reporte { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Canton> Canton { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Pais>  Pais { get; set; }


    }
}
