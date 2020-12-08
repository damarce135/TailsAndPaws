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
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var tPContext = _context.Animal.Include(a => a.IdOrganizacionNavigation);
            return View(await tPContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.IdOrganizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var tamanos = new List<string> { "Muy pequeño", "Pequeño", "Mediano", "Grande" };
            ViewData["Tamano"] = new SelectList(tamanos);

            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion.Where(o => o.Tipo == "Casa Cuna"), "IdOrganizacion", "Nombre");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnimal,Nombre,Sexo,Tamano,Castrado,Edad,FechaIngreso,Caracteristicas,IdOrganizacion,Especie,Adoptado")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var tamanos = new List<string> { "Muy pequeño", "Pequeño", "Mediano", "Grande" };
            ViewData["Tamano"] = new SelectList(tamanos);

            //ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion.Where(o => o.Tipo == "Casa Cuna"), "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var tamanos = new List<string> { "Muy pequeño", "Pequeño", "Mediano", "Grande" };
            ViewData["Tamano"] = new SelectList(tamanos);

            //ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion.Where(o => o.Tipo == "Casa Cuna"), "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimal,Nombre,Sexo,Tamano,Castrado,Edad,FechaIngreso,Caracteristicas,IdOrganizacion,Especie,Adoptado")] Animal animal)
        {
            if (id != animal.IdAnimal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.IdAnimal))
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
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var tamanos = new List<string> { "Muy pequeño", "Pequeño", "Mediano", "Grande" };
            ViewData["Tamano"] = new SelectList(tamanos);

            //ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion.Where(o => o.Tipo == "Casa Cuna"), "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.IdOrganizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalExiste = _context.Adopcion.FromSqlRaw("select * from adopcion where idAnimal = " + id).ToList().Count;
            if (animalExiste > 0)
            {
                return NotFound($"Error: El animalito tiene una adopción registrada. Elimine la adopción para poder eliminar el animalito.");
            }
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.IdAnimal == id);
        }
    }
}
