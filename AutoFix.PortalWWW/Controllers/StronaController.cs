using AutoFix.Data;
using AutoFix.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;

namespace AutoFix.PortalWWW.Controllers
{
    public class StronaController : BaseController
    {
        private readonly AutoFixContext _context;

        public StronaController(AutoFixContext context) : base(context)
        {
            _context = context;
        }

        public IActionResult Szczegoly(int id)
        {
            var strona = _context.Strony.FirstOrDefault(x => x.IdStrony == id);
            if (strona == null)
                return NotFound();

            return View(strona);
        }
    }
}

