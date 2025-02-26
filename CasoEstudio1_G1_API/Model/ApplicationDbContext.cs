using Microsoft.EntityFrameworkCore;

namespace CasoEstudio1_G1_API.Models
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

    }
}
