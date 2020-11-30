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

namespace TP.Controllers
{
    public class DonanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonanteController(ApplicationDbContext context)
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

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0, bounds.Bottom + 90, graphics.ClientSize.Width, 30);
            //Draws a rectangle to place the heading in that region.
            graphics.DrawRectangle(solidBrush, bounds);
            //Creates a font for adding the heading in the page
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            //Creates a text element to add the invoice number
            PdfTextElement element = new PdfTextElement("Adopción ", subHeadingFont);
            element.Brush = PdfBrushes.White;

            //Draws the heading on the page
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "DATE " + DateTime.Now.ToString("dd/MM/yyyy");
            //Measures the width of the text to place it in the correct location
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            //Draws the date by using DrawString method
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.Helvetica, 10);

            //Falta obtener la data


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
