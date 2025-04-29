using AutoFix.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AutoFix.PortalWWW.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AutoFixContext _context;

        public BaseController(AutoFixContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.ModelStrony = _context.Strony.OrderBy(s => s.Pozycja).ToList();
            ViewBag.ModelAktualnosci = _context.Aktualnosci.OrderByDescending(a => a.Pozycja).ToList();

            base.OnActionExecuting(context);
        }
    }
}

