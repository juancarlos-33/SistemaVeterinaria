using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVeterinaria.Models
{
    public class Raza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdEspecie { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [ForeignKey("IdEspecie")]
        public Especie? Especie { get; set; }

        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
