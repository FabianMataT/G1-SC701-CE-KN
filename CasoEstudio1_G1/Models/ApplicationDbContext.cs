using Microsoft.EntityFrameworkCore;

namespace CasoEstudio1_G1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<HorarioRuta> HorariosRutas { get; set; }
        public DbSet<ParadaRuta> ParadasRutas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Ruta>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<HorarioRuta>()
                .HasOne(hr => hr.Horario)
                .WithMany()
                .HasForeignKey(hr => hr.HorarioId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<HorarioRuta>()
                .HasOne(hr => hr.Ruta)
                .WithMany()
                .HasForeignKey(hr => hr.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParadaRuta>()
                .HasOne(pr => pr.Parada)
                .WithMany()
                .HasForeignKey(pr => pr.ParadaId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ParadaRuta>()
                .HasOne(pr => pr.Ruta)
                .WithMany()
                .HasForeignKey(pr => pr.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Estado)
                .WithMany()
                .HasForeignKey(v => v.EstadoId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Usuario)
                .WithMany()
                .HasForeignKey(v => v.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Ruta)
                .WithMany()
                .HasForeignKey(v => v.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Usuario)
                .WithMany()
                .HasForeignKey(b => b.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Boleto>()
                .HasOne(b => b.Vehiculo)
                .WithMany()
                .HasForeignKey(b => b.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
