using System.ComponentModel.DataAnnotations;

namespace SistemaVeterinaria.Models
{
    public class Especie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public ICollection<Raza> Razas { get; set; } = new List<Raza>();
    }
}
