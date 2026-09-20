using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVeterinaria.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int IdPropietario { get; set; }

        [Required]
        public int IdRaza { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Peso { get; set; }

        [MaxLength(255)]
        public string? RutaFoto { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietario? Propietario { get; set; }

        [ForeignKey("IdRaza")]
        public Raza? Raza { get; set; }
    }
}
