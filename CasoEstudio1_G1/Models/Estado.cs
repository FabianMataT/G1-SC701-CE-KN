using System.ComponentModel.DataAnnotations;

namespace CasoEstudio1_G1.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
