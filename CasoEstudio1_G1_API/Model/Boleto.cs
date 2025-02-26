using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio1_G1_API.Models
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
