using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoFix.Data;
using AutoFix.Data.Data.Garaz;
using AutoFix.Intranet.ViewModels;

namespace AutoFix.Intranet.Controllers
{
    public class RezerwacjaController : Controller
    {
        private readonly AutoFixContext _context;

        public RezerwacjaController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: Rezerwacja
        public async Task<IActionResult> Index()
        {
            var autoFixIntranetContext = _context.Rezerwacje.Include(r => r.Klient);
            return View(await autoFixIntranetContext.ToListAsync());
        }

        // GET: Rezerwacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Klient)
                .FirstOrDefaultAsync(m => m.IdRezerwacji == id);

            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacja/Create
        public IActionResult Create()
        {
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email");
            return View();
        }

        // POST: Rezerwacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRezerwacji,DataRezerwacji,Usluga,Uwagi,IdKlienta")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", rezerwacja.IdKlienta);
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", rezerwacja.IdKlienta);
            return View(rezerwacja);
        }

        // POST: Rezerwacja/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRezerwacji,DataRezerwacji,Usluga,Uwagi,IdKlienta")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.IdRezerwacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.IdRezerwacji))
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

            ViewData["IdKlienta"] = new SelectList(_context.Klienci, "IdKlienta", "Email", rezerwacja.IdKlienta);
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Klient)
                .FirstOrDefaultAsync(m => m.IdRezerwacji == id);

            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Rezerwacje.Remove(rezerwacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacje.Any(e => e.IdRezerwacji == id);
        }

        // GET: Rezerwacja/RezerwacjaDashboard
        public async Task<IActionResult> RezerwacjaDashboard()
        {
            var rezerwacje = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.Pojazd)
                .Include(r => r.Mechanik)
                .ToListAsync();

            var viewModel = rezerwacje.Select(r => new RezerwacjaDashboardViewModel
            {
                IdRezerwacji = r.IdRezerwacji,
                DataRezerwacji = r.DataRezerwacji,
                Usluga = r.Usluga,
                Uwagi = r.Uwagi,
                KlientEmail = r.Klient?.Email ?? "Brak danych",
                PojazdOpis = r.Pojazd != null
                    ? $"{r.Pojazd.Marka} {r.Pojazd.Model} ({r.Pojazd.NrRejestracyjny})"
                    : "Brak pojazdu",
                MechanikImieNazwisko = r.Mechanik != null
                    ? $"{r.Mechanik.Imie} {r.Mechanik.Nazwisko}"
                    : "Nieprzypisany"
            }).ToList();

            return View(viewModel);
        }
        // GET: Rezerwacja/Zarzadzaj/5
        public async Task<IActionResult> Zarzadzaj(int? id)
        {
            if (id == null)
                return NotFound();

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.Pojazd)
                .FirstOrDefaultAsync(r => r.IdRezerwacji == id);

            if (rezerwacja == null)
                return NotFound();
            ViewData["Mechanicy"] = new SelectList(
                _context.Mechanicy.Select(m => new {
                    m.IdMechanika,
                    PelnaNazwa = m.Imie + " " + m.Nazwisko
                }), "IdMechanika", "PelnaNazwa", rezerwacja.IdMechanika);

            return View(rezerwacja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Zarzadzaj(int id, [Bind("IdRezerwacji,DataRezerwacji,Usluga,Uwagi,IdMechanika")] Rezerwacja model)
        {
            if (id != model.IdRezerwacji)
                return NotFound();

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Pojazd)
                .FirstOrDefaultAsync(r => r.IdRezerwacji == id);

            if (rezerwacja == null || rezerwacja.Pojazd == null)
                return NotFound();

            // Odczyt checkboxa z formularza
            var autoZastepczeWybrane = Request.Form["autoZastepcze"] == "on";

            // Aktualizuj dane rezerwacji
            rezerwacja.DataRezerwacji = model.DataRezerwacji;
            rezerwacja.Usluga = model.Usluga;
            rezerwacja.Uwagi = model.Uwagi;
            rezerwacja.IdMechanika = model.IdMechanika;

            // Utwórz nową naprawę
            var naprawa = new Naprawa
            {
                DataPrzyjecia = model.DataRezerwacji,
                Opis = model.Usluga,
                IdPojazdu = rezerwacja.Pojazd.IdPojazdu,
                IdMechanika = model.IdMechanika,
                AutoZastepcze = autoZastepczeWybrane,
                Status = "Przyjęta"
            };

            _context.Naprawy.Add(naprawa);
            await _context.SaveChangesAsync();

            if (naprawa.AutoZastepcze)
            {
                var auto = new AutoZastepcze
                {
                    IdNaprawy = naprawa.IdNaprawy,
                    DataOd = naprawa.DataPrzyjecia,
                    Koszt = 100,
                    OpisNaprawy = naprawa.Opis
                };

                _context.AutaZastepcze.Add(auto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Drukuj", "Naprawa", new { id = naprawa.IdNaprawy });
        }
    }
}
