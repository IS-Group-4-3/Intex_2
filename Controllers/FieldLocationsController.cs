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
    public class FieldLocationsController : Controller
    {
        private readonly postgresContext _context;

        public FieldLocationsController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldLocations.ToListAsync());
        }

        // GET: FieldLocations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldLocation = await _context.FieldLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (fieldLocation == null)
            {
                return NotFound();
            }

            return View(fieldLocation);
        }

        // GET: FieldLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,BurialAreaNorthOrSouth,Burialnors,BurialAreaEastOrWest,Burialxeorw,Square,BurialNumber,BurialWestToHead,BurialWestToFeet,BurialSouthToHead,BurialSouthToFeet,BurialDepth,BurialDirection")] FieldLocation fieldLocation)
        {
            if (ModelState.IsValid)
            {
                fieldLocation.LocationId = fieldLocation.BurialAreaNorthOrSouth + fieldLocation.Burialnors + fieldLocation.BurialAreaEastOrWest + fieldLocation.Burialxeorw + fieldLocation.Square + fieldLocation.BurialNumber;
                _context.Add(fieldLocation);
                await _context.SaveChangesAsync();
                TempData["loc"] = fieldLocation.LocationId;
                return RedirectToAction("Create", "FieldMains");
            }
            return View(fieldLocation);
        }

        // GET: FieldLocations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldLocation = await _context.FieldLocations.FindAsync(id);
            if (fieldLocation == null)
            {
                return NotFound();
            }
            return View(fieldLocation);
        }

        // POST: FieldLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,BurialAreaNorthOrSouth,Burialnors,BurialAreaEastOrWest,Burialxeorw,Square,BurialNumber,BurialWestToHead,BurialWestToFeet,BurialSouthToHead,BurialSouthToFeet,BurialDepth,BurialDirection")] FieldLocation fieldLocation)
        {
            if (id != fieldLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldLocationExists(fieldLocation.LocationId))
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
            return View(fieldLocation);
        }

        // GET: FieldLocations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldLocation = await _context.FieldLocations
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (fieldLocation == null)
            {
                return NotFound();
            }

            return View(fieldLocation);
        }

        // POST: FieldLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldLocation = await _context.FieldLocations.FindAsync(id);
            _context.FieldLocations.Remove(fieldLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldLocationExists(string id)
        {
            return _context.FieldLocations.Any(e => e.LocationId == id);
        }
    }
}
