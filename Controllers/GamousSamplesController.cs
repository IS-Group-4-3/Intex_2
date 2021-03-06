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
    public class GamousSamplesController : Controller
    {
        private readonly postgresContext _context;

        public GamousSamplesController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousSamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousSamples.ToListAsync());
        }

        // GET: GamousSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousSample = await _context.GamousSamples
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousSample == null)
            {
                return NotFound();
            }

            return View(gamousSample);
        }

        // GET: GamousSamples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamousSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gamous,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken")] GamousSample gamousSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousSample);
                await _context.SaveChangesAsync();
                string locationId = _context.GamousMains.Where(x => x.Gamous == gamousSample.Gamous).FirstOrDefault().LocationId.ToString();

                return RedirectToAction("DetailsMummies", "Home", new { locationId = locationId });
            }
            return View(gamousSample);
        }

        // GET: GamousSamples/Edit/5
        public async Task<IActionResult> Edit(int? gamous)
        {
            if (gamous == null)
            {
                return NotFound();
            }

            var gamousSample = await _context.GamousSamples.FindAsync(gamous);
            if (gamousSample == null)
            {
                return NotFound();
            }
            return View(gamousSample);
        }

        // POST: GamousSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int gamous, [Bind("Gamous,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken")] GamousSample gamousSample)
        {
            if (gamous != gamousSample.Gamous)
            {
                return NotFound();
            }
            var locationID = _context.GamousMains.Where(x => x.Gamous == gamousSample.Gamous).FirstOrDefault().LocationId.ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousSampleExists(gamousSample.Gamous))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("DetailsMummies", "Home", new { locationId = locationID });
            }
            return View(gamousSample);
        }

        // GET: GamousSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousSample = await _context.GamousSamples
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousSample == null)
            {
                return NotFound();
            }

            return View(gamousSample);
        }

        // POST: GamousSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamousSample = await _context.GamousSamples.FindAsync(id);
            _context.GamousSamples.Remove(gamousSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousSampleExists(int id)
        {
            return _context.GamousSamples.Any(e => e.Gamous == id);
        }
    }
}
