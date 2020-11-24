using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Controllers
{
    [Authorize(Roles = "Admin,Voluntario")]
    public class AdopcionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopcion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adopcion.ToListAsync());
        }

        // GET: Adopcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcion
                .FirstOrDefaultAsync(m => m.IdAdopcion == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // GET: Adopcion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adopcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdopcion,IdAnimal,IdAdoptante,FechaAdopcion,FechaSeguimiento,Habilitado")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adopcion);
        }

        // GET: Adopcion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcion.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }
            return View(adopcion);
        }

        // POST: Adopcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdopcion,IdAnimal,IdAdoptante,FechaAdopcion,FechaSeguimiento,Habilitado")] Adopcion adopcion)
        {
            if (id != adopcion.IdAdopcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcionExists(adopcion.IdAdopcion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adopcion);
        }

        // GET: Adopcion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcion
                .FirstOrDefaultAsync(m => m.IdAdopcion == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // POST: Adopcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcion = await _context.Adopcion.FindAsync(id);
            _context.Adopcion.Remove(adopcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.Adopcion.Any(e => e.IdAdopcion == id);
        }
    }
}
