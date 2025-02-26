using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio1_G1.Models
{
    public class HorarioRuta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Horario")]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }

        [Required]
        [ForeignKey("Ruta")]
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
    }
}
