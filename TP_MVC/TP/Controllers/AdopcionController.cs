using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;


namespace TP.Controllers
{
    public class AdopcionController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdopcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateAdoptante()
        {
            return RedirectToAction("Create", "Adoptante");
        }

        // GET: Adopcion
        public async Task<IActionResult> Index()
        {
            var tPContext = _context.Adopcion.Include(a => a.IdAdoptanteNavigation).Include(a => a.IdAnimalNavigation);
            return View(await tPContext.ToListAsync());
        }

        // GET: Adopcion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcion
                .Include(a => a.IdAdoptanteNavigation)
                .Include(a => a.IdAnimalNavigation)
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
            ViewData["IdAdoptante"] = new SelectList(_context.Adoptante, "IdAdoptante", "Fullname");
            ViewData["IdAnimal"] = new SelectList(_context.Animal.Where(o => o.Adoptado == false), "IdAnimal", "Fullname");
            return View();
        }

        // POST: Adopcion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdopcion,IdAnimal,IdAdoptante,FechaAdopcion,FechaSeguimiento")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(adopcion);
                    await _context.SaveChangesAsync();

                    string procedure = "EXEC AdoptarAnimal @id = " + adopcion.IdAnimal;
                    await _context.Database.ExecuteSqlRawAsync(procedure);

                    string procedureSeg = "EXEC SeguimientoCalendario @id=" + adopcion.IdAnimal + ", @fecha='" + adopcion.FechaSeguimiento + "'";
                    await _context.Database.ExecuteSqlRawAsync(procedureSeg);

                    return RedirectToAction(nameof(Index));

            }
            ViewData["IdAdoptante"] = new SelectList(_context.Adoptante, "IdAdoptante", "Fullname", adopcion.IdAdoptante);
            ViewData["IdAnimal"] = new SelectList(_context.Animal.Where(o => o.Adoptado == false), "IdAnimal", "Fullname", adopcion.IdAnimal);

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
            ViewData["IdAdoptante"] = new SelectList(_context.Adoptante, "IdAdoptante", "Fullname", adopcion.IdAdoptante);
            ViewData["IdAnimal"] = new SelectList(_context.Animal.Where(o => o.Adoptado == false), "IdAnimal", "Fullname", adopcion.IdAnimal);
            return View(adopcion);
        }

        // POST: Adopcion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdopcion,IdAnimal,IdAdoptante,FechaAdopcion,FechaSeguimiento")] Adopcion adopcion)
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
            ViewData["IdAdoptante"] = new SelectList(_context.Adoptante, "IdAdoptante", "Fullname", adopcion.IdAdoptante);
            ViewData["IdAnimal"] = new SelectList(_context.Animal.Where(o => o.Adoptado == false), "IdAnimal", "Fullname", adopcion.IdAnimal);
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
                .Include(a => a.IdAdoptanteNavigation)
                .Include(a => a.IdAnimalNavigation)
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

            string procedure = "EXEC DesadoptarAnimal @id = " + adopcion.IdAnimal;
            await _context.Database.ExecuteSqlRawAsync(procedure);

            string procedureSeg = "EXEC EliminaSeguimientoCalendario @fecha = '" + adopcion.FechaSeguimiento+"'";
            await _context.Database.ExecuteSqlRawAsync(procedureSeg);

            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.Adopcion.Any(e => e.IdAdopcion == id);
        }
    }
}
