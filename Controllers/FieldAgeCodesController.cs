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
    public class FieldAgeCodesController : Controller
    {
        private readonly postgresContext _context;

        public FieldAgeCodesController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldAgeCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldAgeCodes.ToListAsync());
        }

        // GET: FieldAgeCodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAgeCode = await _context.FieldAgeCodes
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldAgeCode == null)
            {
                return NotFound();
            }

            return View(fieldAgeCode);
        }

        // GET: FieldAgeCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldAgeCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Text")] FieldAgeCode fieldAgeCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldAgeCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldAgeCode);
        }

        // GET: FieldAgeCodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAgeCode = await _context.FieldAgeCodes.FindAsync(id);
            if (fieldAgeCode == null)
            {
                return NotFound();
            }
            return View(fieldAgeCode);
        }

        // POST: FieldAgeCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pk,Text")] FieldAgeCode fieldAgeCode)
        {
            if (id != fieldAgeCode.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldAgeCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldAgeCodeExists(fieldAgeCode.Pk))
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
            return View(fieldAgeCode);
        }

        // GET: FieldAgeCodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAgeCode = await _context.FieldAgeCodes
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldAgeCode == null)
            {
                return NotFound();
            }

            return View(fieldAgeCode);
        }

        // POST: FieldAgeCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldAgeCode = await _context.FieldAgeCodes.FindAsync(id);
            _context.FieldAgeCodes.Remove(fieldAgeCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldAgeCodeExists(string id)
        {
            return _context.FieldAgeCodes.Any(e => e.Pk == id);
        }
    }
}
