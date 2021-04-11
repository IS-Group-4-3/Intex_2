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
    public class FieldGenderCodesController : Controller
    {
        private readonly postgresContext _context;

        public FieldGenderCodesController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldGenderCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldGenderCodes.ToListAsync());
        }

        // GET: FieldGenderCodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldGenderCode = await _context.FieldGenderCodes
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldGenderCode == null)
            {
                return NotFound();
            }

            return View(fieldGenderCode);
        }

        // GET: FieldGenderCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldGenderCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Text")] FieldGenderCode fieldGenderCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldGenderCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldGenderCode);
        }

        // GET: FieldGenderCodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldGenderCode = await _context.FieldGenderCodes.FindAsync(id);
            if (fieldGenderCode == null)
            {
                return NotFound();
            }
            return View(fieldGenderCode);
        }

        // POST: FieldGenderCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pk,Text")] FieldGenderCode fieldGenderCode)
        {
            if (id != fieldGenderCode.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldGenderCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldGenderCodeExists(fieldGenderCode.Pk))
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
            return View(fieldGenderCode);
        }

        // GET: FieldGenderCodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldGenderCode = await _context.FieldGenderCodes
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldGenderCode == null)
            {
                return NotFound();
            }

            return View(fieldGenderCode);
        }

        // POST: FieldGenderCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldGenderCode = await _context.FieldGenderCodes.FindAsync(id);
            _context.FieldGenderCodes.Remove(fieldGenderCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldGenderCodeExists(string id)
        {
            return _context.FieldGenderCodes.Any(e => e.Pk == id);
        }
    }
}
