using Microsoft.EntityFrameworkCore;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Data
{
    public class VeterinariaContext : DbContext
    {
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
        }

        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
    }
}
