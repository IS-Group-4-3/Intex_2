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
    public class GamousCranialsController : Controller
    {
        private readonly postgresContext _context;

        public GamousCranialsController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousCranials
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousCranials.ToListAsync());
        }

        // GET: GamousCranials/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousCranial = await _context.GamousCranials
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousCranial == null)
            {
                return NotFound();
            }

            return View(gamousCranial);
        }

        // GET: GamousCranials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamousCranials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionbregmaHeight,Basionnasion,BasionprosthionLength,BizygomaticDiameter,Nasionprosthion,MaximumNasalBreadth,InterorbitalBreadth,BurialPositioningNorthsouthNumber,BurialPositioningNorthsouthDirection,BurialPositioningEastwestNumber,BurialPositioningEastwestDirection,BurialNumber,BurialDepth,BurialSubplotDirection,BurialArtifactDescription,BuriedWithArtifacts,Gilesgender,Bodygender")] GamousCranial gamousCranial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousCranial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamousCranial);
        }

        // GET: GamousCranials/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousCranial = await _context.GamousCranials.FindAsync(id);
            if (gamousCranial == null)
            {
                return NotFound();
            }
            return View(gamousCranial);
        }

        // POST: GamousCranials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionbregmaHeight,Basionnasion,BasionprosthionLength,BizygomaticDiameter,Nasionprosthion,MaximumNasalBreadth,InterorbitalBreadth,BurialPositioningNorthsouthNumber,BurialPositioningNorthsouthDirection,BurialPositioningEastwestNumber,BurialPositioningEastwestDirection,BurialNumber,BurialDepth,BurialSubplotDirection,BurialArtifactDescription,BuriedWithArtifacts,Gilesgender,Bodygender")] GamousCranial gamousCranial)
        {
            if (id != gamousCranial.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousCranial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousCranialExists(gamousCranial.LocationId))
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
            return View(gamousCranial);
        }

        // GET: GamousCranials/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousCranial = await _context.GamousCranials
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (gamousCranial == null)
            {
                return NotFound();
            }

            return View(gamousCranial);
        }

        // POST: GamousCranials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gamousCranial = await _context.GamousCranials.FindAsync(id);
            _context.GamousCranials.Remove(gamousCranial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousCranialExists(string id)
        {
            return _context.GamousCranials.Any(e => e.LocationId == id);
        }
    }
}
