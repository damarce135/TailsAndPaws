using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Syncfusion.Pdf.Tables;

namespace TP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdopcionController : Controller
    {
 
        private readonly ApplicationDbContext _context;

        public AdopcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult CreateDocument()
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page to the document.
            PdfPage page = doc.Pages.Add();
            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            //Load the image as stream.
            FileStream imageStream = new FileStream(@"\\LAPTOP-OBF9CPL2\Users\Public\Pictures\logo.png", FileMode.Open, FileAccess.Read);
            RectangleF bounds = new RectangleF(225, 20, 50, 50);
            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, bounds);

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(190,183,164));
            bounds = new RectangleF(0, bounds.Bottom + 20, graphics.ClientSize.Width, 30);
            //Draws a rectangle to place the heading in that region.
            graphics.DrawRectangle(solidBrush, bounds);
            //Creates a font for adding the heading in the page
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            //Creates a text element to add the invoice number
            PdfTextElement element = new PdfTextElement("Adopción ", subHeadingFont);
            element.Brush = PdfBrushes.White;

            //Draws the heading on the page
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            //Measures the width of the text to place it in the correct location
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            //Draws the date by using DrawString method
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);

            //Falta obtener la data
           DataTable table = new DataTable();
            //Include columns to the DataTable.

            table.Columns.Add("Animal");
            table.Columns.Add("Adoptante");
            table.Columns.Add("Fecha de Adopción");
            table.Columns.Add("Fecha de Seguimiento");

            //Include rows to the DataTable.
            foreach (var item in from p in _context.Adopcion.Include(a => a.IdAdoptanteNavigation)
                 .Include(a => a.IdAnimalNavigation) select p)
                table.Rows.Add(new string[] { item.IdAnimalNavigation.Nombre, item.IdAdoptanteNavigation.Nombre,
               DateTime.Parse(item.FechaAdopcion.ToString()).ToShortDateString(), item.FechaSeguimiento.ToShortDateString() });

            PdfLightTable pdfLightTable = new PdfLightTable();
            pdfLightTable.DataSource = table;
            //Draw PdfLightTable.

            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            PdfCellStyle altStyle = new PdfCellStyle(font, PdfBrushes.Black, PdfPens.Black);
            altStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(230, 230, 230));

            PdfCellStyle headerStyle = new PdfCellStyle(font, PdfBrushes.Black, PdfPens.Black);
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(190, 183, 164));
            // alterna colores entre rows
            pdfLightTable.Style.AlternateStyle = altStyle;

            pdfLightTable.Style.HeaderStyle = headerStyle;

            pdfLightTable.Style.ShowHeader = true;

            pdfLightTable.Draw(page, new PointF(0, bounds.Bottom ));
            
            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "ReporteAdopciones.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
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

                    string procedureSeg = "EXEC SeguimientoCalendario @id=" + adopcion.IdAnimal + ", @fecha='" + adopcion.FechaSeguimiento.ToString("s") + "'";
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

            string procedureSeg = "EXEC EliminaSeguimientoCalendario @fecha = '" + adopcion.FechaSeguimiento.ToString("s")+"'";
            await _context.Database.ExecuteSqlRawAsync(procedureSeg);

            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.Adopcion.Any(e => e.IdAdopcion == id);
        }
    }
}
