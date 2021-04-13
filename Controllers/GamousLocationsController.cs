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
    public class GamousLocationsController : Controller
    {
        private readonly postgresContext _context;

        public GamousLocationsController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousLocations.ToListAsync());
        }

        // GET: GamousLocations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousLocation = await _context.GamousLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousLocation == null)
            {
                return NotFound();
            }

            return View(gamousLocation);
        }

        // GET: GamousLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamousLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,SouthToHead,SouthToFeet,EastToHead,EastToFeet,HeadDirection")] GamousLocation gamousLocation)
        {
            if (ModelState.IsValid)
            {
                gamousLocation.LocationId = gamousLocation.LowPairNs + gamousLocation.BurialLocationNs + gamousLocation.LowPairEw + gamousLocation.BurialLocationEw + gamousLocation.BurialSubplot + gamousLocation.BurialNumber;
                _context.Add(gamousLocation);
                await _context.SaveChangesAsync();
                TempData["loc"] = gamousLocation.LocationId;
                return RedirectToAction("Create", "GamousMains");
            }
            return View(gamousLocation);
        }

        // GET: GamousLocations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousLocation = await _context.GamousLocations.FindAsync(id);
            if (gamousLocation == null)
            {
                return NotFound();
            }
            return View(gamousLocation);
        }

        // POST: GamousLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,SouthToHead,SouthToFeet,EastToHead,EastToFeet,HeadDirection")] GamousLocation gamousLocation)
        {
            if (id != gamousLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousLocationExists(gamousLocation.LocationId))
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
            return View(gamousLocation);
        }

        // GET: GamousLocations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousLocation = await _context.GamousLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousLocation == null)
            {
                return NotFound();
            }

            return View(gamousLocation);
        }

        // POST: GamousLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gamousLocation = await _context.GamousLocations.FindAsync(id);
            _context.GamousLocations.Remove(gamousLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousLocationExists(string id)
        {
            return _context.GamousLocations.Any(e => e.LocationId == id);
        }
    }
}
