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
    public class BasvuruStajbilgisController : Controller
    {
        private readonly INTERNContext _context;

        public BasvuruStajbilgisController(INTERNContext context)
        {
            _context = context;
        }

        // GET: BasvuruStajbilgis
        public async Task<IActionResult> Index()
        {
            var iNTERNContext = _context.BasvuruStajbilgis.Include(b => b.TcnoNavigation);
            return View(await iNTERNContext.ToListAsync());
        }

        // GET: BasvuruStajbilgis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BasvuruStajbilgis == null)
            {
                return NotFound();
            }

            var basvuruStajbilgi = await _context.BasvuruStajbilgis
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruStajbilgi == null)
            {
                return NotFound();
            }

            return View(basvuruStajbilgi);
        }

        // GET: BasvuruStajbilgis/Create
        public IActionResult Create()
        {
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno");
            return View();
        }

        // POST: BasvuruStajbilgis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tcno,Zorunlustaj,Stajtur,Stajsure,Stajsuretipi,Stajdonem,Stajyaptimi")] BasvuruStajbilgi basvuruStajbilgi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basvuruStajbilgi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruStajbilgi.Tcno);
            return View(basvuruStajbilgi);
        }

        // GET: BasvuruStajbilgis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BasvuruStajbilgis == null)
            {
                return NotFound();
            }

            var basvuruStajbilgi = await _context.BasvuruStajbilgis.FindAsync(id);
            if (basvuruStajbilgi == null)
            {
                return NotFound();
            }
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruStajbilgi.Tcno);
            return View(basvuruStajbilgi);
        }

        // POST: BasvuruStajbilgis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tcno,Zorunlustaj,Stajtur,Stajsure,Stajsuretipi,Stajdonem,Stajyaptimi")] BasvuruStajbilgi basvuruStajbilgi)
        {
            if (id != basvuruStajbilgi.Tcno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basvuruStajbilgi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasvuruStajbilgiExists(basvuruStajbilgi.Tcno))
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
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruStajbilgi.Tcno);
            return View(basvuruStajbilgi);
        }

        // GET: BasvuruStajbilgis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BasvuruStajbilgis == null)
            {
                return NotFound();
            }

            var basvuruStajbilgi = await _context.BasvuruStajbilgis
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruStajbilgi == null)
            {
                return NotFound();
            }

            return View(basvuruStajbilgi);
        }

        // POST: BasvuruStajbilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BasvuruStajbilgis == null)
            {
                return Problem("Entity set 'INTERNContext.BasvuruStajbilgis'  is null.");
            }
            var basvuruStajbilgi = await _context.BasvuruStajbilgis.FindAsync(id);
            if (basvuruStajbilgi != null)
            {
                _context.BasvuruStajbilgis.Remove(basvuruStajbilgi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasvuruStajbilgiExists(string id)
        {
          return (_context.BasvuruStajbilgis?.Any(e => e.Tcno == id)).GetValueOrDefault();
        }
    }
}
