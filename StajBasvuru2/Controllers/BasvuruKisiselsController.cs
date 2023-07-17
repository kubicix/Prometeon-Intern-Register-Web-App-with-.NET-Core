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
    public class BasvuruKisiselsController : Controller
    {
        private readonly INTERNContext _context;

        public BasvuruKisiselsController(INTERNContext context)
        {
            _context = context;
        }

        // GET: BasvuruKisisels
        public async Task<IActionResult> Index()
        {
              return _context.BasvuruKisisels != null ? 
                          View(await _context.BasvuruKisisels.ToListAsync()) :
                          Problem("Entity set 'INTERNContext.BasvuruKisisels'  is null.");
        }

        // GET: BasvuruKisisels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BasvuruKisisels == null)
            {
                return NotFound();
            }

            var basvuruKisisel = await _context.BasvuruKisisels
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruKisisel == null)
            {
                return NotFound();
            }

            return View(basvuruKisisel);
        }

        // GET: BasvuruKisisels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasvuruKisisels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adsoyad,Tcno,Telno,Email")] BasvuruKisisel basvuruKisisel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basvuruKisisel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basvuruKisisel);
        }

        // GET: BasvuruKisisels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BasvuruKisisels == null)
            {
                return NotFound();
            }

            var basvuruKisisel = await _context.BasvuruKisisels.FindAsync(id);
            if (basvuruKisisel == null)
            {
                return NotFound();
            }
            return View(basvuruKisisel);
        }

        // POST: BasvuruKisisels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Adsoyad,Tcno,Telno,Email")] BasvuruKisisel basvuruKisisel)
        {
            if (id != basvuruKisisel.Tcno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basvuruKisisel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasvuruKisiselExists(basvuruKisisel.Tcno))
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
            return View(basvuruKisisel);
        }

        // GET: BasvuruKisisels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BasvuruKisisels == null)
            {
                return NotFound();
            }

            var basvuruKisisel = await _context.BasvuruKisisels
                .FirstOrDefaultAsync(m => m.Tcno == id);
            if (basvuruKisisel == null)
            {
                return NotFound();
            }

            return View(basvuruKisisel);
        }

        // POST: BasvuruKisisels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BasvuruKisisels == null)
            {
                return Problem("Entity set 'INTERNContext.BasvuruKisisels'  is null.");
            }
            var basvuruKisisel = await _context.BasvuruKisisels.FindAsync(id);
            if (basvuruKisisel != null)
            {
                _context.BasvuruKisisels.Remove(basvuruKisisel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasvuruKisiselExists(string id)
        {
          return (_context.BasvuruKisisels?.Any(e => e.Tcno == id)).GetValueOrDefault();
        }
    }
}
