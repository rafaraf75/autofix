using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoFix.Data.Data.Garaz;
using AutoFix.Data;

namespace AutoFix.Intranet.Controllers
{
    public class PojazdController : Controller
    {
        private readonly AutoFixContext _context;

        public PojazdController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: Pojazd
        public async Task<IActionResult> Index()
        {
            var autoFixIntranetContext = _context.Pojazdy.Include(p => p.Klient);
            return View(await autoFixIntranetContext.ToListAsync());
        }

        // GET: Pojazd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _context.Pojazdy
                .Include(p => p.Klient)
                .FirstOrDefaultAsync(m => m.IdPojazdu == id);
            if (pojazd == null)
            {
                return NotFound();
            }

            return View(pojazd);
        }

        // GET: Pojazd/Create
        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email");
            return View();
        }

        // POST: Pojazd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPojazdu,Marka,Model,Rok,NrRejestracyjny,IdKlienta")] Pojazd pojazd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pojazd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", pojazd.IdKlienta);
            return View(pojazd);
        }

        // GET: Pojazd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _context.Pojazdy.FindAsync(id);
            if (pojazd == null)
            {
                return NotFound();
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", pojazd.IdKlienta);
            return View(pojazd);
        }

        // POST: Pojazd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPojazdu,Marka,Model,Rok,NrRejestracyjny,IdKlienta")] Pojazd pojazd)
        {
            if (id != pojazd.IdPojazdu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pojazd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PojazdExists(pojazd.IdPojazdu))
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
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", pojazd.IdKlienta);
            return View(pojazd);
        }

        // GET: Pojazd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pojazd = await _context.Pojazdy
                .Include(p => p.Klient)
                .FirstOrDefaultAsync(m => m.IdPojazdu == id);
            if (pojazd == null)
            {
                return NotFound();
            }

            return View(pojazd);
        }

        // POST: Pojazd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pojazd = await _context.Pojazdy.FindAsync(id);
            if (pojazd != null)
            {
                _context.Pojazdy.Remove(pojazd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PojazdExists(int id)
        {
            return _context.Pojazdy.Any(e => e.IdPojazdu == id);
        }
    }
}
