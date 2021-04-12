using Intex_2.Models;
using Intex_2.Models.ViewModels;
using Intex_2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Controllers
{
    
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        private readonly postgresContext _con;
        private readonly IS3Service _s3;
        public int PageSize = 10;
        
        public HomeController(ILogger<HomeController> logger, postgresContext con, IS3Service s3)
        {
            _logger = logger;
            _con = con;
            _s3 = s3;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult ListMummies(int pageNum = 1)
        {
            return View(new MummyListViewModel
            { 
                mummies = _con.GamousMains
                    .OrderBy(b => b.Gamous)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _con.GamousMains.Count()
                    //TotalNumItems = teamId == null ? _context.Bowlers.Count() :
                    //    _context.Bowlers.Where(x => x.TeamId == teamId).Count()
                },

            });
        }

        public IActionResult Test()
        {
            return View(new MummyDetailsViewModel { });
        }

        public IActionResult Test2()
        {
            return View(new MummyDetailsViewModel { });
        }

        public IActionResult Map()
        {
            return View();
        }

        public IActionResult UploadMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadMedia(UploadFileViewModel upload)
        {
            if (ModelState.IsValid)
            {
                string url = await _s3.AddItem(upload.photo, "test");
            }
            else
            {

            }

            return View();
        }

        public IActionResult DetailsMummies(string locationID)
        {
            GamousMain g = _con.GamousMains.FirstOrDefault(p => p.LocationId == locationID);
            GamousLocation gl = _con.GamousLocations.FirstOrDefault(p => p.LocationId == locationID);
            GamousDental gd = _con.GamousDentals.FirstOrDefault(p => p.Gamous == g.Gamous);
            GamousCranial gc = _con.GamousCranials.FirstOrDefault(p => p.LocationId == locationID);
            GamousC14 gc14 = _con.GamousC14s.FirstOrDefault(p => p.LoctionId == locationID);
            GamousBone gb = _con.GamousBones.FirstOrDefault(p => p.Gamous == g.Gamous);
            GamousBiologicalSample gbs = _con.GamousBiologicalSamples.FirstOrDefault(p => p.LocationId == locationID);
            FieldMain fm = _con.FieldMains.FirstOrDefault(p => p.LocationId == locationID);
            FieldLocation fl = _con.FieldLocations.FirstOrDefault(p => p.LocationId == locationID);
            GamousSample gs = _con.GamousSamples.FirstOrDefault(p => p.Gamous == g.Gamous);

            return View(new MummyDetailsViewModel
            {
                mummy = g,
                location = gl,
                dentalInfo = gd,
                cranialInfo = gc,
                carbonDating = gc14,
                bone = gb,
                bioSample = gbs,
                field = fm,
                fieldLocation = fl,
                sample = gs

            }) ;
        }
        public IActionResult RedirectToEditMummies(MummyDetailsViewModel m)
        {
            return View("EditMummy", m);
        }

        [HttpPost]
        public IActionResult EditMummy(MummyDetailsViewModel eM)
        {
            MummyDetailsViewModel m = new MummyDetailsViewModel { };

            m.mummy = _con.GamousMains.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.location = _con.GamousLocations.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.dentalInfo = _con.GamousDentals.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);
            m.cranialInfo = _con.GamousCranials.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.carbonDating = _con.GamousC14s.FirstOrDefault(p => p.LoctionId == eM.mummy.LocationId);
            m.bone = _con.GamousBones.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);
            m.bioSample = _con.GamousBiologicalSamples.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.field = _con.FieldMains.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.sample = _con.GamousSamples.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);

            if (ModelState.IsValid)
            {
                m.mummy = eM.mummy;
                m.location = eM.location;
                m.dentalInfo = eM.dentalInfo;
                m.cranialInfo = eM.cranialInfo;
                m.carbonDating = eM.carbonDating;
                m.bone = eM.bone;
                m.bioSample = eM.bioSample;
                m.field = eM.field;
                m.sample = eM.sample;
                _con.SaveChanges();
            }
            else
            {
                return View(m);
            }

            return View("ConfirmEdit", m);
        }

        public IActionResult ConfirmEdit(MummyDetailsViewModel eM)
        {
            

            return View();
        }

        public IActionResult DeleteMummy(MummyDetailsViewModel eM)
        {
            MummyDetailsViewModel m = new MummyDetailsViewModel { };

            m.mummy = _con.GamousMains.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.location = _con.GamousLocations.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.dentalInfo = _con.GamousDentals.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);
            m.cranialInfo = _con.GamousCranials.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.carbonDating = _con.GamousC14s.FirstOrDefault(p => p.LoctionId == eM.mummy.LocationId);
            m.bone = _con.GamousBones.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);
            m.bioSample = _con.GamousBiologicalSamples.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.field = _con.FieldMains.FirstOrDefault(p => p.LocationId == eM.mummy.LocationId);
            m.sample = _con.GamousSamples.FirstOrDefault(p => p.Gamous == eM.mummy.Gamous);

            _con.Remove(m.mummy);
            _con.Remove(m.location);
            _con.Remove(m.dentalInfo);
            _con.Remove(m.cranialInfo);
            _con.Remove(m.cranialInfo);
            _con.Remove(m.bone);
            _con.Remove(m.bioSample);
            _con.Remove(m.field);
            _con.Remove(m.sample);
            _con.SaveChanges();

            return View();
        }

        [Authorize]
        public IActionResult OsteologyForm()
        {
            return View();
        }

        [Authorize]
        public IActionResult ExhumationForm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
