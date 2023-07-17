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
    public class BasvuruReferansController : Controller
    {
        private readonly INTERNContext _context;

        public BasvuruReferansController(INTERNContext context)
        {
            _context = context;
        }

        // GET: BasvuruReferans
        public async Task<IActionResult> Index()
        {
            var iNTERNContext = _context.BasvuruReferans.Include(b => b.TcnoNavigation);
            return View(await iNTERNContext.ToListAsync());
        }

        // GET: BasvuruReferans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BasvuruReferans == null)
            {
                return NotFound();
            }

            var basvuruReferans = await _context.BasvuruReferans
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruReferans == null)
            {
                return NotFound();
            }

            return View(basvuruReferans);
        }

        // GET: BasvuruReferans/Create
        public IActionResult Create()
        {
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno");
            return View();
        }

        // POST: BasvuruReferans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tcno,Calisanakraba,Yakinlikderecesi,Referansadsoyad,Referanstelefon,Referansemail,Referansbolum,Ekstrabilgi")] BasvuruReferans basvuruReferans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basvuruReferans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruReferans.Tcno);
            return View(basvuruReferans);
        }

        // GET: BasvuruReferans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BasvuruReferans == null)
            {
                return NotFound();
            }

            var basvuruReferans = await _context.BasvuruReferans.FindAsync(id);
            if (basvuruReferans == null)
            {
                return NotFound();
            }
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruReferans.Tcno);
            return View(basvuruReferans);
        }

        // POST: BasvuruReferans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Tcno,Calisanakraba,Yakinlikderecesi,Referansadsoyad,Referanstelefon,Referansemail,Referansbolum,Ekstrabilgi")] BasvuruReferans basvuruReferans)
        {
            if (id != basvuruReferans.Tcno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basvuruReferans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasvuruReferansExists(basvuruReferans.Tcno))
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
            ViewData["Tcno"] = new SelectList(_context.BasvuruKisisels, "Tcno", "Tcno", basvuruReferans.Tcno);
            return View(basvuruReferans);
        }

        // GET: BasvuruReferans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BasvuruReferans == null)
            {
                return NotFound();
            }

            var basvuruReferans = await _context.BasvuruReferans
                .Include(b => b.TcnoNavigation)
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruReferans == null)
            {
                return NotFound();
            }

            return View(basvuruReferans);
        }

        // POST: BasvuruReferans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BasvuruReferans == null)
            {
                return Problem("Entity set 'INTERNContext.BasvuruReferans'  is null.");
            }
            var basvuruReferans = await _context.BasvuruReferans.FindAsync(id);
            if (basvuruReferans != null)
            {
                _context.BasvuruReferans.Remove(basvuruReferans);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasvuruReferansExists(string id)
        {
          return (_context.BasvuruReferans?.Any(e => e.Tcno == id)).GetValueOrDefault();
        }
    }
}
