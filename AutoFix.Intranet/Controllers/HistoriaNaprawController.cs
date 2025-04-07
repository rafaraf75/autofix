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
    public class HistoriaNaprawController : Controller
    {
        private readonly AutoFixContext _context;

        public HistoriaNaprawController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: HistoriaNapraw
        public async Task<IActionResult> Index()
        {
            var autoFixIntranetContext = _context.HistorieNapraw.Include(h => h.Naprawa);
            return View(await autoFixIntranetContext.ToListAsync());
        }

        // GET: HistoriaNapraw/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaNaprawy = await _context.HistorieNapraw
                .Include(h => h.Naprawa)
                .FirstOrDefaultAsync(m => m.IdHistorii == id);
            if (historiaNaprawy == null)
            {
                return NotFound();
            }

            return View(historiaNaprawy);
        }

        // GET: HistoriaNapraw/Create
        public IActionResult Create()
        {
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis");
            return View();
        }

        // POST: HistoriaNapraw/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorii,DataZmiany,OpisZmiany,IdNaprawy")] HistoriaNaprawy historiaNaprawy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaNaprawy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", historiaNaprawy.IdNaprawy);
            return View(historiaNaprawy);
        }

        // GET: HistoriaNapraw/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaNaprawy = await _context.HistorieNapraw.FindAsync(id);
            if (historiaNaprawy == null)
            {
                return NotFound();
            }
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", historiaNaprawy.IdNaprawy);
            return View(historiaNaprawy);
        }

        // POST: HistoriaNapraw/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistorii,DataZmiany,OpisZmiany,IdNaprawy")] HistoriaNaprawy historiaNaprawy)
        {
            if (id != historiaNaprawy.IdHistorii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaNaprawy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaNaprawyExists(historiaNaprawy.IdHistorii))
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
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", historiaNaprawy.IdNaprawy);
            return View(historiaNaprawy);
        }

        // GET: HistoriaNapraw/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaNaprawy = await _context.HistorieNapraw
                .Include(h => h.Naprawa)
                .FirstOrDefaultAsync(m => m.IdHistorii == id);
            if (historiaNaprawy == null)
            {
                return NotFound();
            }

            return View(historiaNaprawy);
        }

        // POST: HistoriaNapraw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historiaNaprawy = await _context.HistorieNapraw.FindAsync(id);
            if (historiaNaprawy != null)
            {
                _context.HistorieNapraw.Remove(historiaNaprawy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaNaprawyExists(int id)
        {
            return _context.HistorieNapraw.Any(e => e.IdHistorii == id);
        }
    }
}
