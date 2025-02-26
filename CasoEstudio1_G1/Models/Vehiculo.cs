using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio1_G1.Models
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Placa { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Modelo { get; set; } = string.Empty;

        public int CapacidadPasajeros { get; set; }

        public DateTime FechaRegistro { get; set; }

        [Required]
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("Ruta")]
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
    }
}
