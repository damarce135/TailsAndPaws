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
    public class DonanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donante
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donante.ToListAsync());
        }

        // GET: Donante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante
                .FirstOrDefaultAsync(m => m.IdDonante == id);
            if (donante == null)
            {
                return NotFound();
            }

            return View(donante);
        }

        // GET: Donante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonante,Nombre,Apellido1,Apellido2,Telefono,Email")] Donante donante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donante);
        }

        // GET: Donante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante.FindAsync(id);
            if (donante == null)
            {
                return NotFound();
            }
            return View(donante);
        }

        // POST: Donante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonante,Nombre,Apellido1,Apellido2,Telefono,Email")] Donante donante)
        {
            if (id != donante.IdDonante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonanteExists(donante.IdDonante))
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
            return View(donante);
        }

        // GET: Donante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donante = await _context.Donante
                .FirstOrDefaultAsync(m => m.IdDonante == id);
            if (donante == null)
            {
                return NotFound();
            }

            return View(donante);
        }

        // POST: Donante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donante = await _context.Donante.FindAsync(id);
            _context.Donante.Remove(donante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonanteExists(int id)
        {
            return _context.Donante.Any(e => e.IdDonante == id);
        }
    }
}
