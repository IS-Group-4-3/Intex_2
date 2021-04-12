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
    public class FieldMainsController : Controller
    {
        private readonly postgresContext _context;

        public FieldMainsController(postgresContext context)
        {
            _context = context;
        }

        // GET: FieldMains
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldMains.ToListAsync());
        }

        // GET: FieldMains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldMain = await _context.FieldMains
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (fieldMain == null)
            {
                return NotFound();
            }

            return View(fieldMain);
        }

        // GET: FieldMains/Create
        public IActionResult CreateFieldMains()
        {
            return View();
        }

        // POST: FieldMains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysisYear,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,Rack,Shelf,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma1,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel,AreaHillBurials,Tomb,LocationId,BurialDepth,LengthOfRemains,YearExcavated,MonthExcavated,DateExcavated,BurialPreservation,BurialWrapping,BurialAdultChild,GenderCode,BurialGenderMethod,AgeCode,BurialAgeAtDeath,BurialAgeMethod,HairColorCode,BurialHairColorText,BurialSampleTaken,LengthM,Goods,ClusterNum,FaceBundle,OsteologyNotes,FieldNotes")] FieldMain fieldMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldMain);
        }

        // GET: FieldMains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldMain = await _context.FieldMains.FindAsync(id);
            if (fieldMain == null)
            {
                return NotFound();
            }
            return View(fieldMain);
        }

        // POST: FieldMains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("YearOnSkull,MonthOnSkull,DateOnSkull,FieldBook,FieldBookPageNumber,InitialsOfDataEntryExpert,InitialsOfDataEntryChecker,ByuSample,BodyAnalysisYear,SkullAtMagazine,PostcraniaAtMagazine,SexSkull2018,AgeSkull2018,Rack,Shelf,RackAndShelf,ToBeConfirmed,SkullTrauma,PostcraniaTrauma,CribraOrbitala,PoroticHyperostosis,PoroticHyperostosisLocations,MetopicSuture,ButtonOsteoma,PostcraniaTrauma1,OsteologyUnknownComment,TemporalMandibularJointOsteoarthritisTmjOa,LinearHypoplasiaEnamel,AreaHillBurials,Tomb,LocationId,BurialDepth,LengthOfRemains,YearExcavated,MonthExcavated,DateExcavated,BurialPreservation,BurialWrapping,BurialAdultChild,GenderCode,BurialGenderMethod,AgeCode,BurialAgeAtDeath,BurialAgeMethod,HairColorCode,BurialHairColorText,BurialSampleTaken,LengthM,Goods,ClusterNum,FaceBundle,OsteologyNotes,FieldNotes")] FieldMain fieldMain)
        {
            if (id != fieldMain.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldMainExists(fieldMain.LocationId))
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
            return View(fieldMain);
        }

        // GET: FieldMains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldMain = await _context.FieldMains
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (fieldMain == null)
            {
                return NotFound();
            }

            return View(fieldMain);
        }

        // POST: FieldMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fieldMain = await _context.FieldMains.FindAsync(id);
            _context.FieldMains.Remove(fieldMain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldMainExists(string id)
        {
            return _context.FieldMains.Any(e => e.LocationId == id);
        }
    }
}
