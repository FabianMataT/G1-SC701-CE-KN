using Microsoft.EntityFrameworkCore;

namespace CasoEstudio1_G1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .HasData(
                    new Estado { Id = 1, Nombre = "Bueno" },
                    new Estado { Id = 2, Nombre = "Regular" },
                    new Estado { Id = 3, Nombre = "Necesita mantenimiento" }
                );

            modelBuilder.Entity<Rol>()
                .HasData(
                    new Rol { Id = 1, Nombre = "Administrador" },
                    new Rol { Id = 2, Nombre = "Conductor" },
                    new Rol { Id = 3, Nombre = "Usuario" }
                );

            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario { Id = 1, NombreUsuario = "fabi", NombreCompleto="Fabian Mata", Correo="fabian@gmail.com", Telefono = "684634524", Contrasenna="12345678", RolId = 1},
                    new Usuario { Id = 2, NombreUsuario = "rodo", NombreCompleto = "Rodolfo Cruz", Correo = "rodolfo@gmail.com", Telefono = "96939564", Contrasenna = "12345678", RolId = 1 },
                    new Usuario { Id = 3, NombreUsuario = "mari", NombreCompleto = "Maria Canales", Correo = "maria@gmail.com", Telefono = "35784925", Contrasenna = "12345678", RolId = 2 },
                    new Usuario { Id = 4, NombreUsuario = "cris", NombreCompleto = "Cristopher Nuñez", Correo = "cristopher@gmail.com", Telefono = "684634524", Contrasenna = "12345678", RolId = 3 }
                );

            modelBuilder.Entity<Horario>()
                .HasData(
                    new Horario { Id = 1, Hora = new TimeSpan(8, 0, 0) },
                    new Horario { Id = 2, Hora = new TimeSpan(12, 0, 0) },
                    new Horario { Id = 3, Hora = new TimeSpan(18, 0, 0) }
                );

            modelBuilder.Entity<Parada>()
                .HasData(
                    new Parada { Id = 1, Nombre = "Parada 1" },
                    new Parada { Id = 2, Nombre = "Parada 2" },
                    new Parada { Id = 3, Nombre = "Parada 3" }
                );

            modelBuilder.Entity<Ruta>()
                .HasData(
                    new Ruta { Id = 1, NombreRuta = "Ruta 1", Descripcion = "Ruta principal", Estado = true, FechaRegistro = DateTime.Now, UsuarioId = 1 },
                    new Ruta { Id = 2, NombreRuta = "Ruta 2", Descripcion = "Ruta secundaria", Estado = true, FechaRegistro = DateTime.Now, UsuarioId = 2 }
                );

            modelBuilder.Entity<HorarioRuta>()
                .HasData(
                    new HorarioRuta { Id = 1, HorarioId = 1, RutaId = 1 },
                    new HorarioRuta { Id = 2, HorarioId = 2, RutaId = 2 }
                );

            modelBuilder.Entity<ParadaRuta>()
                .HasData(
                    new ParadaRuta { Id = 1, ParadaId = 1, RutaId = 1 },
                    new ParadaRuta { Id = 2, ParadaId = 2, RutaId = 1 },
                    new ParadaRuta { Id = 3, ParadaId = 3, RutaId = 2 }
                );

            modelBuilder.Entity<Vehiculo>()
                .HasData(
                    new Vehiculo { Id = 1, Placa = "ABC123", Modelo = "Modelo X", CapacidadPasajeros = 50, FechaRegistro = DateTime.Now, EstadoId = 1, UsuarioId = 1, RutaId = 1 },
                    new Vehiculo { Id = 2, Placa = "DEF456", Modelo = "Modelo Y", CapacidadPasajeros = 40, FechaRegistro = DateTime.Now, EstadoId = 2, UsuarioId = 2, RutaId = 2 }
                );

            modelBuilder.Entity<Boleto>()
                .HasData(
                    new Boleto { Id = 1, UsuarioId = 3, VehiculoId = 1 },
                    new Boleto { Id = 2, UsuarioId = 4, VehiculoId = 2 }
                );
        }
    }
}
