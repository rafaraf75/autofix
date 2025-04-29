using AutoFix.Data;
using AutoFix.Data.Data;
using AutoFix.Data.Data.Garaz;
using AutoFix.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoFix.PortalWWW.Controllers
{
    public class RezerwacjaController : BaseController
    {
        private readonly AutoFixContext _context;

        public RezerwacjaController(AutoFixContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NowaRezerwacjaVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var pojazd = _context.Pojazdy.FirstOrDefault(p => p.NrRejestracyjny == model.NrRejestracyjny);

            if (pojazd == null)
            {
                ModelState.AddModelError("NrRejestracyjny", "Nie znaleziono pojazdu o podanym numerze.");
                return View(model);
            }

            var nowa = new Rezerwacja
            {
                DataRezerwacji = model.DataRezerwacji,
                Usluga = model.Usluga,
                Uwagi = model.Uwagi ?? string.Empty,
                IdPojazdu = pojazd.IdPojazdu,
                IdKlienta = pojazd.IdKlienta
            };

            _context.Rezerwacje.Add(nowa);
            _context.SaveChanges();

            return RedirectToAction("Potwierdzenie");
        }
        [HttpGet]
        public IActionResult SzukajPojazdPoRejestracji(string nr)
        {
            var pojazd = _context.Pojazdy
                .Include(p => p.Klient)
                .FirstOrDefault(p => p.NrRejestracyjny.ToLower() == nr.ToLower());

            if (pojazd == null)
            {
                return NotFound(new { message = "Nie znaleziono pojazdu" });
            }

            return Json(new
            {
                idPojazdu = pojazd.IdPojazdu,
                idKlienta = pojazd.IdKlienta,
                klient = new
                {
                    imie = pojazd.Klient!.Imie,
                    nazwisko = pojazd.Klient.Nazwisko
                },
                pojazd = new
                {
                    marka = pojazd.Marka,
                    model = pojazd.Model,
                    silnik = pojazd.Silnik
                }
            });
        }
        [HttpGet]
        public IActionResult Potwierdzenie()
        {
            return View();
        }
    }
}
