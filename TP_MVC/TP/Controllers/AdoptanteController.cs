﻿using System;
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
    public class AdoptanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateAdopcion()
        {
            return RedirectToAction("Create", "Adopcion");
        }

        // GET: Adoptante
        public async Task<IActionResult> Index()
        {
            var tPContext = _context.Adoptante.Include(a => a.IdProvinciaNavigation);
            return View(await tPContext.ToListAsync());
        }

        // GET: Adoptante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptante
                //.Include(a => a.IdCantonNavigation)
                //.Include(a => a.IdDistritoNavigation)
                .Include(a => a.IdProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdoptante == id);
            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // GET: Adoptante/Create
        public IActionResult Create()
        {
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton");
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito");
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia");
            return View();
        }

        // POST: Adoptante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdoptante,Cedula,Nombre,Apellido1,Apellido2,Email,Telefono,IdProvincia,DetalleDireccion,Habilitado")] Adoptante adoptante)
        {

            if (ModelState.IsValid)
                    {
                if (_context.Adoptante.Any(x => x.Cedula == adoptante.Cedula))
                {
                    ViewBag.Error = "Error: Ya esta cédula está registrada.";
                    ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", adoptante.IdProvincia);
                    return View(adoptante);
                    //return NotFound("Error: Ya esta cédula está registrada.");
                }
                      _context.Add(adoptante);
                        await _context.SaveChangesAsync();

                        string bitacora = "EXEC addBitacora @accion= 'Create' , @detalle='Se creó el adoptante " + adoptante.Cedula + "'";
                        await _context.Database.ExecuteSqlRawAsync(bitacora);

                        return RedirectToAction(nameof(Index));
                    }
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", adoptante.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", adoptante.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", adoptante.IdProvincia);
            return View(adoptante);
        }

        // GET: Adoptante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptante.FindAsync(id);
            if (adoptante == null)
            {
                return NotFound();
            }
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", adoptante.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", adoptante.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", adoptante.IdProvincia);
            return View(adoptante);
        }

        // POST: Adoptante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdoptante,Cedula,Nombre,Apellido1,Apellido2,Email,Telefono,IdProvincia,DetalleDireccion,Habilitado")] Adoptante adoptante)
        {
            if (id != adoptante.IdAdoptante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptanteExists(adoptante.IdAdoptante))
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
            //ViewData["IdCanton"] = new SelectList(_context.Canton, "IdCanton", "NombreCanton", adoptante.IdCanton);
            //ViewData["IdDistrito"] = new SelectList(_context.Distrito, "IdDistrito", "NombreDistrito", adoptante.IdDistrito);
            ViewData["IdProvincia"] = new SelectList(_context.Provincia, "IdProvincia", "NombreProvincia", adoptante.IdProvincia);
            return View(adoptante);
        }


        // GET: Adoptante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptante
                    //.Include(a => a.IdCantonNavigation)
                    //.Include(a => a.IdDistritoNavigation)
                    .Include(a => a.IdProvinciaNavigation)
                    .FirstOrDefaultAsync(m => m.IdAdoptante == id);

            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // POST: Adoptante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptante1 = await _context.Adoptante
                    .Include(a => a.IdProvinciaNavigation)
                    .FirstOrDefaultAsync(m => m.IdAdoptante == id);
            var adopcionExiste = _context.Adopcion.FromSqlRaw("select * from adopcion where idAdoptante = " + id).ToList().Count;
            if (adopcionExiste > 0)
            {
                ViewBag.Error = "Error: El adoptante tiene una adopción registrada. Elimine la adopción para poder eliminar el adoptante.";
                return View(adoptante1);
                //return NotFound($"Error: El adoptante tiene una adopción registrada. Elimine la adopción para poder eliminar el adoptante.");
            }
            var adoptante = await _context.Adoptante.FindAsync(id);
            _context.Adoptante.Remove(adoptante);
            await _context.SaveChangesAsync();

            string bitacora = "EXEC addBitacora @accion= 'Delete' , @detalle='Se eliminó el adoptante " + adoptante.Cedula + "'";
            await _context.Database.ExecuteSqlRawAsync(bitacora);

            return RedirectToAction(nameof(Index));
        }


        private bool AdoptanteExists(int id)
        {
            return _context.Adoptante.Any(e => e.IdAdoptante == id);
        }

        //private bool AdoptanteExistsInAdoption(Adoptante id)
        //{
        //    return _context.Adopcion.Any(a => a.IdAdoptanteNavigation == id);
        //}
    }
}
