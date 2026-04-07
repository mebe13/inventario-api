using Microsoft.EntityFrameworkCore;
using InventarioAPI.Models;

namespace InventarioAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; } // 👈 ESTA LÍNEA NUEVA

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2);
        }
    }
}