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
    public class FieldBurialWrappingsController : Controller
    {
        private readonly postgresContext _context;

        public FieldBurialWrappingsController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldBurialWrappings
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldBurialWrappings.ToListAsync());
        }

        // GET: FieldBurialWrappings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldBurialWrapping = await _context.FieldBurialWrappings
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldBurialWrapping == null)
            {
                return NotFound();
            }

            return View(fieldBurialWrapping);
        }

        // GET: FieldBurialWrappings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldBurialWrappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Text")] FieldBurialWrapping fieldBurialWrapping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldBurialWrapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldBurialWrapping);
        }

        // GET: FieldBurialWrappings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldBurialWrapping = await _context.FieldBurialWrappings.FindAsync(id);
            if (fieldBurialWrapping == null)
            {
                return NotFound();
            }
            return View(fieldBurialWrapping);
        }

        // POST: FieldBurialWrappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pk,Text")] FieldBurialWrapping fieldBurialWrapping)
        {
            if (id != fieldBurialWrapping.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldBurialWrapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldBurialWrappingExists(fieldBurialWrapping.Pk))
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
            return View(fieldBurialWrapping);
        }

        // GET: FieldBurialWrappings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldBurialWrapping = await _context.FieldBurialWrappings
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldBurialWrapping == null)
            {
                return NotFound();
            }

            return View(fieldBurialWrapping);
        }

        // POST: FieldBurialWrappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldBurialWrapping = await _context.FieldBurialWrappings.FindAsync(id);
            _context.FieldBurialWrappings.Remove(fieldBurialWrapping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldBurialWrappingExists(string id)
        {
            return _context.FieldBurialWrappings.Any(e => e.Pk == id);
        }
    }
}
