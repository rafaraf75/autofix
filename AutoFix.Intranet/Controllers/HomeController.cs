using AutoFix.Data;
using AutoFix.Data.Data.Garaz;
using AutoFix.Intranet.Models;
using AutoFix.Intranet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AutoFix.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AutoFixContext _context;

        public HomeController(ILogger<HomeController> logger, AutoFixContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Dashboard z list¹ rezerwacji
        public IActionResult Index()
        {
            ViewBag.LiczbaKlientow = _context.Klienci.Count();
            ViewBag.LiczbaNapraw = _context.Naprawy.Count();
            ViewBag.LiczbaRezerwacji = _context.Rezerwacje.Count();
            ViewBag.LiczbaMechanikow = _context.Mechanicy.Count();

            var rezerwacjeZBazy = _context.Rezerwacje
                .Include(r => r.Klient)
                .Include(r => r.Pojazd)
                .Include(r => r.Mechanik)
                .OrderByDescending(r => r.DataRezerwacji)
                .Take(10)
                .ToList();

            var rezerwacje = rezerwacjeZBazy.Select(r => new RezerwacjaDashboardViewModel
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

            return View(rezerwacje);
        }

        // GET: Przypisz mechanika do rezerwacji
        public IActionResult PrzypiszMechanika(int id)
        {
            var mechanicy = _context.Mechanicy
                .Select(m => new SelectListItem
                {
                    Value = m.IdMechanika.ToString(),
                    Text = $"{m.Imie} {m.Nazwisko}"
                }).ToList();

            ViewBag.Mechanicy = mechanicy;
            ViewBag.IdRezerwacji = id;

            return View();
        }

        // POST: Zapis przypisania mechanika
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrzypiszMechanika(int id, int idMechanika)
        {
            var rezerwacja = _context.Rezerwacje.FirstOrDefault(r => r.IdRezerwacji == id);
            var mechanik = _context.Mechanicy.FirstOrDefault(m => m.IdMechanika == idMechanika);

            if (rezerwacja == null || mechanik == null)
            {
                TempData["Blad"] = "Nie uda³o siê przypisaæ mechanika. Spróbuj ponownie.";
                return RedirectToAction(nameof(Index));
            }

            rezerwacja.IdMechanika = idMechanika;
            _context.SaveChanges();

            TempData["Sukces"] = "Mechanik zosta³ przypisany do rezerwacji.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
