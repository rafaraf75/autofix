using System.Diagnostics;
using AutoFix.Data;
using AutoFix.PortalWWW.Models;
using AutoFix.PortalWWW.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoFix.PortalWWW.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, AutoFixContext context) : base(context)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeVM
            {
                Promocje = await _context.Promocje.ToListAsync(),
                Uslugi = await _context.Uslugi.ToListAsync()
            };
            return View(vm);
        }

        public IActionResult OpisFirmy()
        {
            return View();
        }

        public IActionResult HistoriaFirmy()
        {
            return View();
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
