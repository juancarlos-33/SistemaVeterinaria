using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVeterinaria.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50)]
        public string Apellido { get; set; }

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Pon un correo válido")]
        public string? Email { get; set; }

        [MaxLength(150)]
        public string? Direccion { get; set; }

        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
