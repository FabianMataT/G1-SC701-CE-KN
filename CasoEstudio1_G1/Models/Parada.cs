using System.ComponentModel.DataAnnotations;

namespace CasoEstudio1_G1.Models
{
    public class Parada
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
    }
}
