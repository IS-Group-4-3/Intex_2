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
    public class FieldHairColorsController : Controller
    {
        private readonly postgresContext _context;

        public FieldHairColorsController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldHairColors
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldHairColors.ToListAsync());
        }

        // GET: FieldHairColors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldHairColor = await _context.FieldHairColors
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldHairColor == null)
            {
                return NotFound();
            }

            return View(fieldHairColor);
        }

        // GET: FieldHairColors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldHairColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Text")] FieldHairColor fieldHairColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldHairColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldHairColor);
        }

        // GET: FieldHairColors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldHairColor = await _context.FieldHairColors.FindAsync(id);
            if (fieldHairColor == null)
            {
                return NotFound();
            }
            return View(fieldHairColor);
        }

        // POST: FieldHairColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pk,Text")] FieldHairColor fieldHairColor)
        {
            if (id != fieldHairColor.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldHairColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldHairColorExists(fieldHairColor.Pk))
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
            return View(fieldHairColor);
        }

        // GET: FieldHairColors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldHairColor = await _context.FieldHairColors
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldHairColor == null)
            {
                return NotFound();
            }

            return View(fieldHairColor);
        }

        // POST: FieldHairColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldHairColor = await _context.FieldHairColors.FindAsync(id);
            _context.FieldHairColors.Remove(fieldHairColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldHairColorExists(string id)
        {
            return _context.FieldHairColors.Any(e => e.Pk == id);
        }
    }
}
