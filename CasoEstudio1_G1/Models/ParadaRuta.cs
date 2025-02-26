using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasoEstudio1_G1.Models
{
    public class ParadaRuta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Parada")]
        public int ParadaId { get; set; }
        public Parada Parada { get; set; }

        [Required]
        [ForeignKey("Ruta")]
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
    }
}
