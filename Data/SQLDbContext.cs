using DesarrolloWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesarrolloWebAPI.Data
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions op) : base(op){}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Detalle_Venta> Detalle_Ventas { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
    }
}
