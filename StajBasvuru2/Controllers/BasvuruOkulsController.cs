using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StajBasvuru2.Models;

namespace StajBasvuru2.Controllers
{
    public class BasvuruOkulsController : Controller
    {
        private readonly INTERNContext _context;

        public BasvuruOkulsController(INTERNContext context)
        {
            _context = context;
        }

        // GET: BasvuruOkuls
        public async Task<IActionResult> Index()
        {
            var iNTERNContext = _context.BasvuruOkuls.Include(b => b.TcnoNavigation);
            return View(await iNTERNContext.ToListAsync());
        }

        // GET: BasvuruOkuls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BasvuruOkuls == null)
            {
                return NotFound();
            }

            var basvuruOkul = await _context.BasvuruOkuls
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruOkul == null)
            {
                return NotFound();
            }

            return View(basvuruOkul);
        }

        // GET: BasvuruOkuls/Create
        public IActionResult Create()
        {
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno");
            return View();
        }

        // POST: BasvuruOkuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tcno,Okultur,Okulad,Bolum,Sınıf,Ortalama,Notsistem")] BasvuruOkul basvuruOkul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basvuruOkul);
                await _context.SaveChangesAsync();
                return PartialView("~/Views/Deneme/Kaydet.cshtml");
            }
            else
            {
                ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruOkul.Tcno);
                ViewData["ErrorMessage"] = "Model validation failed.";
                return View(basvuruOkul);
            }
        }

        // GET: BasvuruOkuls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BasvuruOkuls == null)
            {
                return NotFound();
            }

            var basvuruOkul = await _context.BasvuruOkuls.FindAsync(id);
            if (basvuruOkul == null)
            {
                return NotFound();
            }
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruOkul.Tcno);
            return View(basvuruOkul);
        }

        // POST: BasvuruOkuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tcno,Okultur,Okulad,Bolum,Sınıf,Ortalama,Notsistem")] BasvuruOkul basvuruOkul)
        {
            if (id != basvuruOkul.Tcno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basvuruOkul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasvuruOkulExists(basvuruOkul.Tcno))
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
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruOkul.Tcno);
            return View(basvuruOkul);
        }

        // GET: BasvuruOkuls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BasvuruOkuls == null)
            {
                return NotFound();
            }

            var basvuruOkul = await _context.BasvuruOkuls
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruOkul == null)
            {
                return NotFound();
            }

            return View(basvuruOkul);
        }

        // POST: BasvuruOkuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BasvuruOkuls == null)
            {
                return Problem("Entity set 'INTERNContext.BasvuruOkuls'  is null.");
            }
            var basvuruOkul = await _context.BasvuruOkuls.FindAsync(id);
            if (basvuruOkul != null)
            {
                _context.BasvuruOkuls.Remove(basvuruOkul);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasvuruOkulExists(string id)
        {
          return (_context.BasvuruOkuls?.Any(e => e.Tcno == id)).GetValueOrDefault();
        }
    }
}
