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
    public class GamousBonesController : Controller
    {
        private readonly postgresContext _context;

        public GamousBonesController(postgresContext context)
        {
            _context = context;
        }

        // GET: GamousBones
        public async Task<IActionResult> Index()
        {
            return View(await _context.GamousBones.ToListAsync());
        }

        // GET: GamousBones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBone = await _context.GamousBones
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousBone == null)
            {
                return NotFound();
            }

            return View(gamousBone);
        }

        // GET: GamousBones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GamousBones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gamous,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth")] GamousBone gamousBone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamousBone);
                await _context.SaveChangesAsync();
                TempData["gamous"] = gamousBone.Gamous;
                return RedirectToAction("Create", "GamousDentals");
            }
            return View(gamousBone);
        }

        // GET: GamousBones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBone = await _context.GamousBones.FindAsync(id);
            if (gamousBone == null)
            {
                return NotFound();
            }
            return View(gamousBone);
        }

        // POST: GamousBones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Gamous,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,MedialClavicle,IliacCrest,FemurDiameter,Humerus,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth")] GamousBone gamousBone)
        {
            if (id != gamousBone.Gamous)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamousBone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamousBoneExists(gamousBone.Gamous))
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
            return View(gamousBone);
        }

        // GET: GamousBones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamousBone = await _context.GamousBones
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (gamousBone == null)
            {
                return NotFound();
            }

            return View(gamousBone);
        }

        // POST: GamousBones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamousBone = await _context.GamousBones.FindAsync(id);
            _context.GamousBones.Remove(gamousBone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamousBoneExists(int id)
        {
            return _context.GamousBones.Any(e => e.Gamous == id);
        }
    }
}
