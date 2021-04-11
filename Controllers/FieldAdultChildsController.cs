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
    public class FieldAdultChildsController : Controller
    {
        private readonly postgresContext _context;

        public FieldAdultChildsController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldAdultChilds
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldAdultChildren.ToListAsync());
        }

        // GET: FieldAdultChilds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAdultChild = await _context.FieldAdultChildren
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldAdultChild == null)
            {
                return NotFound();
            }

            return View(fieldAdultChild);
        }

        // GET: FieldAdultChilds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldAdultChilds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pk,Text")] FieldAdultChild fieldAdultChild)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldAdultChild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldAdultChild);
        }

        // GET: FieldAdultChilds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAdultChild = await _context.FieldAdultChildren.FindAsync(id);
            if (fieldAdultChild == null)
            {
                return NotFound();
            }
            return View(fieldAdultChild);
        }

        // POST: FieldAdultChilds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pk,Text")] FieldAdultChild fieldAdultChild)
        {
            if (id != fieldAdultChild.Pk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldAdultChild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldAdultChildExists(fieldAdultChild.Pk))
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
            return View(fieldAdultChild);
        }

        // GET: FieldAdultChilds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldAdultChild = await _context.FieldAdultChildren
                .FirstOrDefaultAsync(m => m.Pk == id);
            if (fieldAdultChild == null)
            {
                return NotFound();
            }

            return View(fieldAdultChild);
        }

        // POST: FieldAdultChilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldAdultChild = await _context.FieldAdultChildren.FindAsync(id);
            _context.FieldAdultChildren.Remove(fieldAdultChild);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldAdultChildExists(string id)
        {
            return _context.FieldAdultChildren.Any(e => e.Pk == id);
        }
    }
}
