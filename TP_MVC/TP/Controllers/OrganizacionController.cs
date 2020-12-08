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
            var tPContext = _context.Organizacion.Include(o => o.IdProvinciaNavigation);
            return View(await tPContext.ToListAsync());
        }

        // GET: Organizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizacion = await _context.Organizacion
                //.Include(o => o.IdCantonNavigation)
                //.Include(o => o.IdDistritoNavigation)
                .Include(o => o.IdProvinciaNavigation)
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
            var items = new List<string> { "Proveedor", "Veterinaria", "Casa Cuna", "Colaborador" };
            ViewData["Tipo"] = new SelectList(items);
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton");
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito");
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia");
            return View();
        }

        // POST: Organizacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrganizacion,Tipo,Nombre,Apellido1,Apellido2,Telefono,Email,Descripcion,IdProvincia,DetalleDireccion")] Organizacion organizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var items = new List<string> { "Proveedor", "Veterinaria", "Casa Cuna", "Colaborador" };
            ViewData["Tipo"] = new SelectList(items);
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", organizacion.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", organizacion.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", organizacion.IdProvincia);
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
            var items = new List<string> { "Proveedor", "Veterinaria", "Casa Cuna", "Colaborador" };
            ViewData["Tipo"] = new SelectList(items);
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", organizacion.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", organizacion.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", organizacion.IdProvincia);
            return View(organizacion);
        }

        // POST: Organizacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrganizacion,Tipo,Nombre,Apellido1,Apellido2,Telefono,Email,Descripcion,IdProvincia,DetalleDireccion")] Organizacion organizacion)
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
            var items = new List<string> { "Proveedor", "Veterinaria", "Casa Cuna", "Colaborador" };
            ViewData["Tipo"] = new SelectList(items);
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", organizacion.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", organizacion.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", organizacion.IdProvincia);
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
                //.Include(o => o.IdCantonNavigation)
                //.Include(o => o.IdDistritoNavigation)
                .Include(o => o.IdProvinciaNavigation)
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
            var animalExiste = _context.Animal.FromSqlRaw("select * from animal where idOrganizacion = " + id).ToList().Count;
            if (animalExiste > 0)
            {
                return NotFound($"Error: La organización tiene una animalito registrado. Elimine la casa cuna del animalito para poder eliminarla.");
            }
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
