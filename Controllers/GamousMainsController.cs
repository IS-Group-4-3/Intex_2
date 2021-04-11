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
    public class GamousMainsController : Controller
    {
        private readonly postgresContext _context;

        public GamousMainsController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousMains
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousMains.ToListAsync());
        }

        // GET: GamousMains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousMain = await _context.GamousMains
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousMain == null)
            {
                return NotFound();
            }

            return View(gamousMain);
        }

        // GET: GamousMains/Create
        public IActionResult CreateGamousMains()
        {
            return View();
        }

        // POST: GamousMains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGamousMains([Bind("Gamous,LocationId,BurialSituationNotes,LengthOfRemains,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,ArtifactsDescription,HairColor,PreservationIndex,ArtifactFound,EstimateAge,EstimateLivingStature,DateFound,LengthOfRemainsM,EstimateLivingStatureM")] GamousMain gamousMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamousMain);
        }

        // GET: GamousMains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousMain = await _context.GamousMains.FindAsync(id);
            if (gamousMain == null)
            {
                return NotFound();
            }
            return View(gamousMain);
        }

        // POST: GamousMains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Gamous,LocationId,BurialSituationNotes,LengthOfRemains,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,ArtifactsDescription,HairColor,PreservationIndex,ArtifactFound,EstimateAge,EstimateLivingStature,DateFound,LengthOfRemainsM,EstimateLivingStatureM")] GamousMain gamousMain)
        {
            if (id != gamousMain.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousMainExists(gamousMain.LocationId))
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
            return View(gamousMain);
        }

        // GET: GamousMains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousMain = await _context.GamousMains
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousMain == null)
            {
                return NotFound();
            }

            return View(gamousMain);
        }

        // POST: GamousMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gamousMain = await _context.GamousMains.FindAsync(id);
            _context.GamousMains.Remove(gamousMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousMainExists(string id)
        {
            return _context.GamousMains.Any(e => e.LocationId == id);
        }
    }
}
