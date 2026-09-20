using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVeterinaria.Data;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class PropietariosController : Controller
    {
        // 1. Inyección directa del DbContext (Requisito de la prueba: No usar Repositories)
        private readonly VeterinariaContext _context;

        public PropietariosController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: Propietarios
        public async Task<IActionResult> Index()
        {
            var propietarios = await _context.Propietarios.ToListAsync();
            return View(propietarios);
        }

        // GET: Propietarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
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

        // GET: Propietarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null) return NotFound();

            return View(propietario);
        }

        // POST: Propietarios/Edit/5
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

        // GET: Propietarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var propietario = await _context.Propietarios.FirstOrDefaultAsync(m => m.Id == id);
            if (propietario == null) return NotFound();

            return View(propietario);
        }

        // POST: Propietarios/Delete/5
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
