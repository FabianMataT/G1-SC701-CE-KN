using System.ComponentModel.DataAnnotations;

namespace CasoEstudio1_G1_API.Models
{
    public class Horario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }
    }
}
