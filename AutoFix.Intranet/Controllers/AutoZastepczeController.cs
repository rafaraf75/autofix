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
    public class AutoZastepczeController : Controller
    {
        private readonly AutoFixContext _context;

        public AutoZastepczeController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: AutoZastepcze
        public async Task<IActionResult> Index()
        {
            var autoFixIntranetContext = _context.AutaZastepcze.Include(a => a.Naprawa);
            return View(await autoFixIntranetContext.ToListAsync());
        }

        // GET: AutoZastepcze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoZastepcze = await _context.AutaZastepcze
                .Include(a => a.Naprawa)
                .FirstOrDefaultAsync(m => m.IdAutoZastepczego == id);
            if (autoZastepcze == null)
            {
                return NotFound();
            }

            return View(autoZastepcze);
        }

        // GET: AutoZastepcze/Create
        public IActionResult Create()
        {
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis");
            return View();
        }

        // POST: AutoZastepcze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutoZastepczego,DataOd,DataDo,Koszt,IdNaprawy")] AutoZastepcze autoZastepcze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoZastepcze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", autoZastepcze.IdNaprawy);
            return View(autoZastepcze);
        }

        // GET: AutoZastepcze/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoZastepcze = await _context.AutaZastepcze.FindAsync(id);
            if (autoZastepcze == null)
            {
                return NotFound();
            }
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", autoZastepcze.IdNaprawy);
            return View(autoZastepcze);
        }

        // POST: AutoZastepcze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutoZastepczego,DataOd,DataDo,Koszt,IdNaprawy")] AutoZastepcze autoZastepcze)
        {
            if (id != autoZastepcze.IdAutoZastepczego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoZastepcze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoZastepczeExists(autoZastepcze.IdAutoZastepczego))
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
            ViewData["IdNaprawy"] = new SelectList(_context.Set<Naprawa>(), "IdNaprawy", "Opis", autoZastepcze.IdNaprawy);
            return View(autoZastepcze);
        }

        // GET: AutoZastepcze/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoZastepcze = await _context.AutaZastepcze
                .Include(a => a.Naprawa)
                .FirstOrDefaultAsync(m => m.IdAutoZastepczego == id);
            if (autoZastepcze == null)
            {
                return NotFound();
            }

            return View(autoZastepcze);
        }

        // POST: AutoZastepcze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoZastepcze = await _context.AutaZastepcze.FindAsync(id);
            if (autoZastepcze != null)
            {
                _context.AutaZastepcze.Remove(autoZastepcze);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoZastepczeExists(int id)
        {
            return _context.AutaZastepcze.Any(e => e.IdAutoZastepczego == id);
        }
    }
}
