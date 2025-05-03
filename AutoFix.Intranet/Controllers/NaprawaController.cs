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
    public class NaprawaController : Controller
    {
        private readonly AutoFixContext _context;

        public NaprawaController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: Naprawy
        public async Task<IActionResult> Index()
        {
            var autoFixIntranetContext = _context.Naprawy.Include(n => n.Mechanik).Include(n => n.Pojazd);
            return View(await autoFixIntranetContext.ToListAsync());
        }

        // GET: Naprawy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naprawa = await _context.Naprawy
                .Include(n => n.Mechanik)
                .Include(n => n.Pojazd)
                .FirstOrDefaultAsync(m => m.IdNaprawy == id);
            if (naprawa == null)
            {
                return NotFound();
            }

            return View(naprawa);
        }

        // GET: Naprawy/Create
        public IActionResult Create()
        {
            ViewData["IdMechanika"] = new SelectList(_context.Mechanicy, "IdMechanika", "Imie");
            ViewData["IdPojazdu"] = new SelectList(_context.Set<Pojazd>(), "IdPojazdu", "Marka");
            return View();
        }

        // POST: Naprawy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNaprawy,DataPrzyjecia,Opis,Status,AutoZastepcze,IdPojazdu,IdMechanika")] Naprawa naprawa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naprawa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMechanika"] = new SelectList(_context.Mechanicy, "IdMechanika", "Imie", naprawa.IdMechanika);
            ViewData["IdPojazdu"] = new SelectList(_context.Set<Pojazd>(), "IdPojazdu", "Marka", naprawa.IdPojazdu);
            return View(naprawa);
        }

        // GET: Naprawy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naprawa = await _context.Naprawy.FindAsync(id);
            if (naprawa == null)
            {
                return NotFound();
            }
            ViewData["IdMechanika"] = new SelectList(_context.Mechanicy, "IdMechanika", "Imie", naprawa.IdMechanika);
            ViewData["IdPojazdu"] = new SelectList(_context.Set<Pojazd>(), "IdPojazdu", "Marka", naprawa.IdPojazdu);
            return View(naprawa);
        }

        // POST: Naprawy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNaprawy,DataPrzyjecia,Opis,Status,AutoZastepcze,IdPojazdu,IdMechanika")] Naprawa naprawa)
        {
            if (id != naprawa.IdNaprawy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naprawa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaprawaExists(naprawa.IdNaprawy))
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
            ViewData["IdMechanika"] = new SelectList(_context.Mechanicy, "IdMechanika", "Imie", naprawa.IdMechanika);
            ViewData["IdPojazdu"] = new SelectList(_context.Set<Pojazd>(), "IdPojazdu", "Marka", naprawa.IdPojazdu);
            return View(naprawa);
        }

        // GET: Naprawy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naprawa = await _context.Naprawy
                .Include(n => n.Mechanik)
                .Include(n => n.Pojazd)
                .FirstOrDefaultAsync(m => m.IdNaprawy == id);
            if (naprawa == null)
            {
                return NotFound();
            }

            return View(naprawa);
        }

        // POST: Naprawy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naprawa = await _context.Naprawy.FindAsync(id);
            if (naprawa != null)
            {
                _context.Naprawy.Remove(naprawa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaprawaExists(int id)
        {
            return _context.Naprawy.Any(e => e.IdNaprawy == id);
        }

        public IActionResult Drukuj(int id)
        {
            var naprawa = _context.Naprawy
                .Include(n => n.Mechanik)
                .Include(n => n.Pojazd)
                .FirstOrDefault(n => n.IdNaprawy == id);

            if (naprawa == null)
                return NotFound();

            return View("Drukuj", naprawa);
        }

        [HttpPost]
        public async Task<IActionResult> Zakoncz(int id)
        {
            var naprawa = await _context.Naprawy
                .Include(n => n.Pojazd)
                .FirstOrDefaultAsync(n => n.IdNaprawy == id);

            if (naprawa == null)
                return NotFound();

            // 1. Zapisz historię
            var historia = new HistoriaNaprawy
            {
                DataZmiany = DateTime.Now,
                OpisZmiany = $"Naprawa zakończona: {naprawa.Opis}",
                IdNaprawy = naprawa.IdNaprawy,
                OpisNaprawy = naprawa.Opis
            };
            _context.HistorieNapraw.Add(historia);

            // 2. Zaktualizuj auto zastępcze jeśli istnieje
            if (naprawa.AutoZastepcze)
            {
                var auto = await _context.AutaZastepcze
                    .FirstOrDefaultAsync(a => a.IdNaprawy == naprawa.IdNaprawy);

                if (auto != null)
                {
                    auto.DataDo = DateTime.Now;
                    auto.OpisNaprawy = naprawa.Opis;
                    auto.IdNaprawy = null;
                }
            }

            // 3. Usuń naprawę
            _context.Naprawy.Remove(naprawa);

            await _context.SaveChangesAsync();
            TempData["Sukces"] = "Naprawa została zakończona i przeniesiona do historii.";

            return RedirectToAction("Index");
        }
    }
}
