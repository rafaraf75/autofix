using AutoFix.Data;
using AutoFix.Data.Data.Garaz;
using AutoFix.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoFix.PortalWWW.Controllers
{
    public class PortalController : BaseController
    {
        private readonly AutoFixContext _context;

        public PortalController(AutoFixContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DodajKlientaPojazd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DodajKlientaPojazd(DodajKlientaPojazdVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Tworzymy klienta
            var klient = new Klient
            {
                Imie = viewModel.Imie,
                Nazwisko = viewModel.Nazwisko,
                Email = viewModel.Email,
                Telefon = viewModel.Telefon
            };
            _context.Klienci.Add(klient);
            _context.SaveChanges(); // Żeby dostać IdKlienta

            // Tworzymy pojazd powiązany z klientem
            var pojazd = new Pojazd
            {
                Marka = viewModel.Marka,
                Model = viewModel.Model,
                Rok = viewModel.Rok,
                NrRejestracyjny = viewModel.NrRejestracyjny,
                Silnik = viewModel.Silnik,
                IdKlienta = klient.IdKlienta
            };
            _context.Pojazdy.Add(pojazd);
            _context.SaveChanges();

            return RedirectToAction("Potwierdzenie");
        }

        public IActionResult Potwierdzenie()
        {
            return View();
        }
    }
}
