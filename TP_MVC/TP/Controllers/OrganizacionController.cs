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
    [Authorize(Roles = "Admin")]
    public class OrganizacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organizacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizacion.ToListAsync());
        }

        // GET: Organizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion
                .FirstOrDefaultAsync(m => m.IdOrganizacion == id);
            if (organizacion == null)
            {
                return NotFound();
            }

            return View(organizacion);
        }

        // GET: Organizacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrganizacion,Tipo,Nombre,Apellido1,Apellido2,Telefono,Email,Descripcion,IdProvincia,IdCanton,IdDistrito,DetalleDireccion,Habilitado")] Organizacion organizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizacion);
        }

        // GET: Organizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion.FindAsync(id);
            if (organizacion == null)
            {
                return NotFound();
            }
            return View(organizacion);
        }

        // POST: Organizacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrganizacion,Tipo,Nombre,Apellido1,Apellido2,Telefono,Email,Descripcion,IdProvincia,IdCanton,IdDistrito,DetalleDireccion,Habilitado")] Organizacion organizacion)
        {
            if (id != organizacion.IdOrganizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizacionExists(organizacion.IdOrganizacion))
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
            return View(organizacion);
        }

        // GET: Organizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion
                .FirstOrDefaultAsync(m => m.IdOrganizacion == id);
            if (organizacion == null)
            {
                return NotFound();
            }

            return View(organizacion);
        }

        // POST: Organizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizacion = await _context.Organizacion.FindAsync(id);
            _context.Organizacion.Remove(organizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizacionExists(int id)
        {
            return _context.Organizacion.Any(e => e.IdOrganizacion == id);
        }
    }
}
