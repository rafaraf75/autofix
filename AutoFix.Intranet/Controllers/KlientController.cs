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
    public class KlientController : Controller
    {
        private readonly AutoFixContext _context;

        public KlientController(AutoFixContext context)
        {
            _context = context;
        }

        // GET: Klient
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klienci.ToListAsync());
        }

        // GET: Klient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci
                .FirstOrDefaultAsync(m => m.IdKlienta == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // GET: Klient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKlienta,Imie,Nazwisko,Telefon,Email")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klient);
        }

        // GET: Klient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            return View(klient);
        }

        // POST: Klient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKlienta,Imie,Nazwisko,Telefon,Email")] Klient klient)
        {
            if (id != klient.IdKlienta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.IdKlienta))
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
            return View(klient);
        }

        // GET: Klient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci
                .FirstOrDefaultAsync(m => m.IdKlienta == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient != null)
            {
                _context.Klienci.Remove(klient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return _context.Klienci.Any(e => e.IdKlienta == id);
        }
    }
}
