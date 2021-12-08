using DesarrolloWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesarrolloWebAPI.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions option):base(option){}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Detalle_Venta> Detalle_Ventas { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
