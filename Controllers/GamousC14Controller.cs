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
    public class GamousC14Controller : Controller
    {
        private readonly postgresContext _context;

        public GamousC14Controller(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousC14
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousC14s.ToListAsync());
        }

        // GET: GamousC14/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousC14 = await _context.GamousC14s
                .FirstOrDefaultAsync(m => m.LoctionId == id);
            if (gamousC14 == null)
            {
                return NotFound();
            }

            return View(gamousC14);
        }

        // GET: GamousC14/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamousC14/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoctionId,Rack,Ns,LocationNs,Ew,LocationEw,Square,Area,Burial,Tube,Description,SizeMl,Foci,C14Sample2017,Location,Questions,SomeNumber,Conventional14cAgeBp,C14CalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] GamousC14 gamousC14)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousC14);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamousC14);
        }

        // GET: GamousC14/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousC14 = await _context.GamousC14s.FindAsync(id);
            if (gamousC14 == null)
            {
                return NotFound();
            }
            return View(gamousC14);
        }

        // POST: GamousC14/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LoctionId,Rack,Ns,LocationNs,Ew,LocationEw,Square,Area,Burial,Tube,Description,SizeMl,Foci,C14Sample2017,Location,Questions,SomeNumber,Conventional14cAgeBp,C14CalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] GamousC14 gamousC14)
        {
            if (id != gamousC14.LoctionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousC14);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousC14Exists(gamousC14.LoctionId))
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
            return View(gamousC14);
        }

        // GET: GamousC14/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousC14 = await _context.GamousC14s
                .FirstOrDefaultAsync(m => m.LoctionId == id);
            if (gamousC14 == null)
            {
                return NotFound();
            }

            return View(gamousC14);
        }

        // POST: GamousC14/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gamousC14 = await _context.GamousC14s.FindAsync(id);
            _context.GamousC14s.Remove(gamousC14);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousC14Exists(string id)
        {
            return _context.GamousC14s.Any(e => e.LoctionId == id);
        }
    }
}
