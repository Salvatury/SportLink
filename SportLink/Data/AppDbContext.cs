using Microsoft.EntityFrameworkCore;
using SportLink.Entidades;

namespace SportLink.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Liga> Ligas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<FechaTorneo> FechasTorneo { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Resultado> Resultados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.EquipoLocal)
                .WithMany(e => e.PartidosComoLocal)
                .HasForeignKey(p => p.EquipoLocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.EquipoVisitante)
                .WithMany(e => e.PartidosComoVisitante)
                .HasForeignKey(p => p.EquipoVisitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partido>()
                .HasOne(p => p.Arbitro)
                .WithMany(u => u.PartidosArbitrados)
                .HasForeignKey(p => p.ArbitroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.Partido)
                .WithOne(p => p.Resultado)
                .HasForeignKey<Resultado>(r => r.PartidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Resultado>()
                .HasOne(r => r.CargadoPorUsuario)
                .WithMany(u => u.ResultadosCargados)
                .HasForeignKey(r => r.CargadoPorUsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}