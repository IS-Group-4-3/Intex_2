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
    public class GamousBiologicalSamplesController : Controller
    {
        private readonly postgresContext _context;

        public GamousBiologicalSamplesController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousBiologicalSamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousBiologicalSamples.ToListAsync());
        }

        // GET: GamousBiologicalSamples/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBiologicalSample = await _context.GamousBiologicalSamples
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousBiologicalSample == null)
            {
                return NotFound();
            }

            return View(gamousBiologicalSample);
        }

        // GET: GamousBiologicalSamples/Create
        public IActionResult CreateBiologicalSamples()
        {
            return View();
        }

        // POST: GamousBiologicalSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBiologicalSamples([Bind("LocationId,RackNumber,BagNumber,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,ClusterNumber,Date,PreviouslySampled,Notes,Initials")] GamousBiologicalSample gamousBiologicalSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousBiologicalSample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamousBiologicalSample);
        }

        // GET: GamousBiologicalSamples/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBiologicalSample = await _context.GamousBiologicalSamples.FindAsync(id);
            if (gamousBiologicalSample == null)
            {
                return NotFound();
            }
            return View(gamousBiologicalSample);
        }

        // POST: GamousBiologicalSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,RackNumber,BagNumber,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,ClusterNumber,Date,PreviouslySampled,Notes,Initials")] GamousBiologicalSample gamousBiologicalSample)
        {
            if (id != gamousBiologicalSample.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousBiologicalSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousBiologicalSampleExists(gamousBiologicalSample.LocationId))
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
            return View(gamousBiologicalSample);
        }

        // GET: GamousBiologicalSamples/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBiologicalSample = await _context.GamousBiologicalSamples
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousBiologicalSample == null)
            {
                return NotFound();
            }

            return View(gamousBiologicalSample);
        }

        // POST: GamousBiologicalSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gamousBiologicalSample = await _context.GamousBiologicalSamples.FindAsync(id);
            _context.GamousBiologicalSamples.Remove(gamousBiologicalSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousBiologicalSampleExists(string id)
        {
            return _context.GamousBiologicalSamples.Any(e => e.LocationId == id);
        }
    }
}
