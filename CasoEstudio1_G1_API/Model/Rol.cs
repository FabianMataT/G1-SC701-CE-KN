using System.ComponentModel.DataAnnotations;

namespace CasoEstudio1_G1_API.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
