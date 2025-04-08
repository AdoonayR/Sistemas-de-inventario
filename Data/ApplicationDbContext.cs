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

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
