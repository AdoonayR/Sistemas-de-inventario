using Microsoft.EntityFrameworkCore;
using Sistemas_de_inventario.Models;

namespace Sistemas_de_inventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets basados en nuestros modelos:
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
    }
}
