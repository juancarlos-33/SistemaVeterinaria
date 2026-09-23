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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especie>().HasData(
                new Especie { Id = 1, Nombre = "Canino" },
                new Especie { Id = 2, Nombre = "Felino" }
            );

            modelBuilder.Entity<Raza>().HasData(
                new Raza { Id = 1, IdEspecie = 1, Nombre = "Labrador" },
                new Raza { Id = 2, IdEspecie = 1, Nombre = "Pastor Alemán" },
                new Raza { Id = 3, IdEspecie = 2, Nombre = "Siamés" },
                new Raza { Id = 4, IdEspecie = 2, Nombre = "Persa" }
            );
        }
    }
}
