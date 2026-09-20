using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVeterinaria.Data;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class MascotasController : Controller
    {
        private readonly VeterinariaContext _db;
        private readonly IWebHostEnvironment _env;

        public MascotasController(VeterinariaContext context, IWebHostEnvironment env)
        {
            _db = context;
            _env = env;
        }

        public async Task<IActionResult> Index(string buscarTexto, int? especieId)
        {
            ViewBag.Especies = new SelectList(_db.Especies, "Id", "Nombre");

            var query = _db.Mascotas
                .Include(m => m.Propietario)
                .Include(m => m.Raza)
                .ThenInclude(r => r.Especie)
                .AsQueryable();

            if (!string.IsNullOrEmpty(buscarTexto))
            {
                query = query.Where(m => m.Nombre.Contains(buscarTexto) 
                                      || m.Propietario.Nombre.Contains(buscarTexto));
            }

            if (especieId.HasValue && especieId > 0)
            {
                query = query.Where(m => m.Raza.IdEspecie == especieId);
            }

            var listado = await query.ToListAsync();
            return View(listado);
        }

        [HttpGet]
        public async Task<JsonResult> CargarRazas(int idEspecie)
        {
            var razas = await _db.Razas
                .Where(r => r.IdEspecie == idEspecie)
                .Select(r => new { value = r.Id, text = r.Nombre })
                .ToListAsync();
                
            return Json(razas);
        }

        public IActionResult Create()
        {
            ViewBag.Propietarios = new SelectList(_db.Propietarios, "Id", "Nombre");
            ViewBag.Especies = new SelectList(_db.Especies, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Mascota mascota, IFormFile foto, int IdEspecie)
        {
            ModelState.Remove("Propietario");
            ModelState.Remove("Raza");

            if (ModelState.IsValid)
            {
                if (foto != null && foto.Length > 0)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                    
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                    var filePath = Path.Combine(uploads, fileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await foto.CopyToAsync(stream);
                    }
                    mascota.RutaFoto = fileName;
                }

                _db.Add(mascota);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Propietarios = new SelectList(_db.Propietarios, "Id", "Nombre", mascota.IdPropietario);
            ViewBag.Especies = new SelectList(_db.Especies, "Id", "Nombre", IdEspecie);
            return View(mascota);
        }
    }
}
