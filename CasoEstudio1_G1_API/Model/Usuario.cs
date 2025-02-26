using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio1_G1_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required, MaxLength(15)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string Contrasenna { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
