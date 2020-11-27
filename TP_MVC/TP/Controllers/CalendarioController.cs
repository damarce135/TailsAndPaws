using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Models;

namespace TP.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly TPContext _context;

        public CalendarioController(TPContext context)
        {
            _context = context;
        }

        // GET: Calendario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Calendarios.ToListAsync());
        }

        // GET: Calendario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.IdCalendario == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // GET: Calendario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calendario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalendario,Asunto,FechaInicio,FechaFinal,Descripcion,DiaCompleto,TemaColor")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendario);
        }

        // GET: Calendario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }
            return View(calendario);
        }

        // POST: Calendario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalendario,Asunto,FechaInicio,FechaFinal,Descripcion,DiaCompleto,TemaColor")] Calendario calendario)
        {
            if (id != calendario.IdCalendario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarioExists(calendario.IdCalendario))
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
            return View(calendario);
        }

        // GET: Calendario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendarios
                .FirstOrDefaultAsync(m => m.IdCalendario == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // POST: Calendario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calendario = await _context.Calendarios.FindAsync(id);
            _context.Calendarios.Remove(calendario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioExists(int id)
        {
            return _context.Calendarios.Any(e => e.IdCalendario == id);
        }
    }
}
