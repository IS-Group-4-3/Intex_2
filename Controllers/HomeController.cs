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

        [HttpGet]
        public IActionResult ListMummies(int pageNum = 1)
        {
            ViewBag.gender_filter = _con.GamousMains.Select(x => x.GenderGe).Distinct().ToList();
            ViewBag.hair_filter = _con.GamousMains.Select(x => x.HairColor).Distinct().ToList();
            ViewBag.date_min = _con.GamousMains.Select(x => x.DateFound).Min();
            ViewBag.date_max = _con.GamousMains.Select(x => x.DateFound).Max();





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



                },



            });
        }



        [HttpPost]
        public IActionResult ListMummies(List<string> gender_filter, List<string> hair_filter, string artifact, int pageNum = 1)
        {
            ViewBag.gender_filter = _con.GamousMains.Select(x => x.GenderGe).Distinct().ToList();
            ViewBag.hair_filter = _con.GamousMains.Select(x => x.HairColor).Distinct().ToList();
            ViewBag.date_min = _con.GamousMains.Select(x => x.DateFound).Min();
            ViewBag.date_max = _con.GamousMains.Select(x => x.DateFound).Max();



            var query = from b in _con.GamousMains select b;



            if (gender_filter.Count() > 0)
            {
                //gender_query = "gender_filter.Contains(b.GenderGe)";
                query = query.Where(b => gender_filter.Contains(b.GenderGe));
            }
            if (hair_filter.Count() > 0)
            {
                query = query.Where(b => hair_filter.Contains(b.HairColor));
            }
            if (artifact != null)
            {
                query = query.Where(b => b.ArtifactFound == artifact);
            }



            query = query
                .OrderBy(b => b.Gamous)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize);



            return View(new MummyListViewModel
            {
                mummies = query,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //TotalNumItems = _con.GamousMains.Count()
                    TotalNumItems = query.Count()
                },



            }); ;
        }

        public IActionResult Test()
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
            string url = null;
            if (ModelState.IsValid)
            {
                url = await _s3.AddItem(upload.photo, "test");
            }
            else
            {
                return View("UploadMedia");
            }

            return View("MediaLibrary", url);
        }

        public IActionResult MediaLibrary(string url)
        {
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

            });
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
            return View(new MummyDetailsViewModel { });
        }

        [Authorize]
        public IActionResult ExhumationForm()
        {
            return View(new MummyDetailsViewModel { });
        }

        public IActionResult About()
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
