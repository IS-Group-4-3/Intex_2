using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intex_2.Models;

namespace Intex_2.Controllers
{
    public class GamousDentalsController : Controller
    {
        private readonly postgresContext _context;

        public GamousDentalsController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousDentals
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousDentals.ToListAsync());
        }

        // GET: GamousDentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousDental = await _context.GamousDentals
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousDental == null)
            {
                return NotFound();
            }

            return View(gamousDental);
        }

        // GET: GamousDentals/Create
        public IActionResult CreateGamousDentals()
        {
            return View();
        }

        // POST: GamousDentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGamousDentals([Bind("Gamous,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion")] GamousDental gamousDental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousDental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamousDental);
        }

        // GET: GamousDentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousDental = await _context.GamousDentals.FindAsync(id);
            if (gamousDental == null)
            {
                return NotFound();
            }
            return View(gamousDental);
        }

        // POST: GamousDentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Gamous,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion")] GamousDental gamousDental)
        {
            if (id != gamousDental.Gamous)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousDental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousDentalExists(gamousDental.Gamous))
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
            return View(gamousDental);
        }

        // GET: GamousDentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousDental = await _context.GamousDentals
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousDental == null)
            {
                return NotFound();
            }

            return View(gamousDental);
        }

        // POST: GamousDentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamousDental = await _context.GamousDentals.FindAsync(id);
            _context.GamousDentals.Remove(gamousDental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousDentalExists(int id)
        {
            return _context.GamousDentals.Any(e => e.Gamous == id);
        }
    }
}
