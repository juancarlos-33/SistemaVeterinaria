using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVeterinaria.Data;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly VeterinariaContext _context;

        public PropietariosController(VeterinariaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var propietarios = await _context.Propietarios.ToListAsync();
            return View(propietarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellido,Telefono,Email,Direccion")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null) return NotFound();

            return View(propietario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Telefono,Email,Direccion")] Propietario propietario)
        {
            if (id != propietario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(propietario.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var propietario = await _context.Propietarios.FirstOrDefaultAsync(m => m.Id == id);
            if (propietario == null) return NotFound();

            return View(propietario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario != null)
            {
                _context.Propietarios.Remove(propietario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PropietarioExists(int id)
        {
            return _context.Propietarios.Any(e => e.Id == id);
        }
    }
}
