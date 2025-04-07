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
    public class MechanikController : Controller
    {
        private readonly AutoFixContext _context;

        public MechanikController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: Mechanik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mechanicy.ToListAsync());
        }

        // GET: Mechanik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechanicy
                .FirstOrDefaultAsync(m => m.IdMechanika == id);
            if (mechanik == null)
            {
                return NotFound();
            }

            return View(mechanik);
        }

        // GET: Mechanik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mechanik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMechanika,Imie,Nazwisko,Specjalizacja")] Mechanik mechanik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mechanik);
        }

        // GET: Mechanik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechanicy.FindAsync(id);
            if (mechanik == null)
            {
                return NotFound();
            }
            return View(mechanik);
        }

        // POST: Mechanik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMechanika,Imie,Nazwisko,Specjalizacja")] Mechanik mechanik)
        {
            if (id != mechanik.IdMechanika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanikExists(mechanik.IdMechanika))
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
            return View(mechanik);
        }

        // GET: Mechanik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechanicy
                .FirstOrDefaultAsync(m => m.IdMechanika == id);
            if (mechanik == null)
            {
                return NotFound();
            }

            return View(mechanik);
        }

        // POST: Mechanik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanik = await _context.Mechanicy.FindAsync(id);
            if (mechanik != null)
            {
                _context.Mechanicy.Remove(mechanik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanikExists(int id)
        {
            return _context.Mechanicy.Any(e => e.IdMechanika == id);
        }
    }
}
