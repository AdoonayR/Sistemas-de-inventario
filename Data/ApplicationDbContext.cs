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

        // DbSets para todos los modelos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<DetalleSolicitud> DetallesSolicitudes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.EmployeeNumber).IsUnique();
                entity.Property(u => u.Password).HasColumnType("nvarchar(100)");
            });

            // Configuración de Material
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasIndex(m => m.NumeroParte).IsUnique();
                entity.Property(m => m.FechaCreacion)
                    .HasDefaultValueSql("GETUTCDATE()");
                entity.Property(m => m.FechaActualizacion)
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAddOrUpdate();

                // Relaciones explícitas
                entity.HasMany(m => m.Lotes)
                    .WithOne(l => l.Material)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(m => m.Movimientos)
                    .WithOne(m => m.Material)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(m => m.DetallesSolicitud)
                    .WithOne(d => d.Material)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Lote
            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasIndex(l => new { l.NumeroLote, l.MaterialId });
                entity.HasOne(l => l.Material)
                    .WithMany(m => m.Lotes)
                    .HasForeignKey(l => l.MaterialId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Solicitud
            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasIndex(s => s.NumeroSolicitud).IsUnique();
                entity.Property(s => s.NumeroSolicitud)
                    .HasDefaultValueSql("'SOL-' + FORMAT(GETUTCDATE(), 'yyyyMMddHHmmss')");

                // Relación con DetallesSolicitud
                entity.HasMany(s => s.Detalles)
                    .WithOne(d => d.Solicitud)
                    .HasForeignKey(d => d.SolicitudId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relación con Movimientos
                entity.HasMany(s => s.Movimientos)
                    .WithOne(m => m.Solicitud)
                    .HasForeignKey(m => m.SolicitudId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración COMPLETA de DetalleSolicitud
            modelBuilder.Entity<DetalleSolicitud>(entity =>
            {
                // Relación con Material
                entity.HasOne(d => d.Material)
                    .WithMany(m => m.DetallesSolicitud)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Solicitud (configuración explícita)
                entity.HasOne(d => d.Solicitud)
                    .WithMany(s => s.Detalles)
                    .HasForeignKey(d => d.SolicitudId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de Movimiento
            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasIndex(m => new { m.MaterialId, m.FechaMovimiento });

                // Relación con Material
                entity.HasOne(m => m.Material)
                    .WithMany(m => m.Movimientos)
                    .HasForeignKey(m => m.MaterialId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Solicitud
                entity.HasOne(m => m.Solicitud)
                    .WithMany(s => s.Movimientos)
                    .HasForeignKey(m => m.SolicitudId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(m => m.FechaMovimiento)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}