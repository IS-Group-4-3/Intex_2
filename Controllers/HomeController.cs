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
        public IActionResult ListMummies(string locationID, int pageNum = 1)
        {
            ViewBag.gender_filter = _con.GamousMains.Select(x => x.GenderGe).Distinct().ToList();
            ViewBag.hair_filter = _con.GamousMains.Select(x => x.HairColor).Distinct().ToList();
            ViewBag.date_min = _con.GamousMains.Select(x => x.DateFound).Min();
            ViewBag.date_max = _con.GamousMains.Select(x => x.DateFound).Max();
            IEnumerable<GamousMain> mummyList = _con.GamousMains;
            PagingInfo PageInfo = new PagingInfo();
            if (locationID != null) {
                mummyList = _con.GamousMains
                    .Where(x => x.LocationId == locationID)
                    .OrderBy(b => b.Gamous)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize);
                PageInfo.CurrentPage = pageNum;
                PageInfo.ItemsPerPage = PageSize;
                PageInfo.TotalNumItems = mummyList.Count();

            }
            else
            {
                mummyList = _con.GamousMains
                    .OrderBy(b => b.Gamous)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize);

                PageInfo.CurrentPage = pageNum;
                PageInfo.ItemsPerPage = PageSize;
                PageInfo.TotalNumItems = _con.GamousMains.Count();
            }

            return View(new MummyListViewModel
            { 
                mummies = mummyList,
                PagingInfo = PageInfo
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

            var items = query.Count();

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
                    TotalNumItems = items
                },

            }); ;
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
            string url;
            if (ModelState.IsValid)
            {
                url = await _s3.AddItem(upload.photo, "test");

                FileRecord File = new FileRecord
                {
                    Url = url,
                    Type = upload.type,
                    LocationId = upload.LowPairNs + upload.BurialLocationNs + upload.LowPairEw + upload.BurialLocationEw + upload.BurialSubplot + upload.BurialNumber
                };

                _con.FileRecords.Add(File);
                _con.SaveChanges();
                return Redirect("MediaLibrary");
            }
            else
            {
                return View("UploadMedia");
            }
        }

        public IActionResult HiddenUploadMedia(string locationID)
        {
            GamousLocation l = _con.GamousLocations.Where(x => x.LocationId == locationID).FirstOrDefault();
            ViewBag.lowpairNs = l.LowPairNs;
            ViewBag.BurialLocationNs = l.BurialLocationNs;
            ViewBag.LowPairEw =l.LowPairEw;
            ViewBag.BurialLocationEw = l.BurialLocationEw;
            ViewBag.BurialSubplot = l.BurialSubplot;
            ViewBag.BurialNumber = l.BurialNumber;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> HiddenUploadMedia(UploadFileViewModel upload)
        {
            string url;
            if (ModelState.IsValid)
            {
                url = await _s3.AddItem(upload.photo, "test");

                FileRecord File = new FileRecord
                {
                    Url = url,
                    Type = upload.type,
                    LocationId = upload.LowPairNs + upload.BurialLocationNs + upload.LowPairEw + upload.BurialLocationEw + upload.BurialSubplot + upload.BurialNumber
                };

                _con.FileRecords.Add(File);
                _con.SaveChanges();
                return Redirect("MediaLibrary");
            }
            else
            {
                return View("UploadMedia");
            }
        }

        public IActionResult MediaLibrary(string type,int pageNum = 1)
        {
            var files = _con.FileRecords;

            return View(new MediaViewModel
            {
                files = files
                    .Where(p => type == null || p.Type == type)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = type == null ? _con.FileRecords.Count() :
                        _con.FileRecords.Where(x => x.Type == type).Count()
                },
                CurrentType = type
            });
        }

        public IActionResult DeleteMedia(string url)
        {
            var image = _con.FileRecords.FirstOrDefault(p => p.Url == url);

            _con.Remove(image);
            _con.SaveChanges();

            return Redirect("MediaLibrary");
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
                IEnumerable<FileRecord> fr = _con.FileRecords.Where(p => p.LocationId == locationID);
            
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
                sample = gs,
                files = fr
            });
        }

        public IActionResult DeleteMummy(string locationID)
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
            IEnumerable<FileRecord> fr = _con.FileRecords.Where(p => p.LocationId == locationID);

            if (g != null)
            { _con.Remove(g); }
            if (gl != null)
            { _con.Remove(gl); }
            if (gd != null)
            { _con.Remove(gd); }
            if (gc != null)
            { _con.Remove(gc); }
            if (gc14 != null)
            { _con.Remove(gc14); }
            if (gb != null)
            { _con.Remove(gb); }
            if (gbs != null)
            { _con.Remove(gbs); }
            if (fm != null)
            { _con.Remove(fm); }
            if (fl != null)
            { _con.Remove(fl); }
            if (gs != null)
            { _con.Remove(gs); }
            if (fr != null)
            {
                foreach (var file in fr)
                {
                    _con.Remove(file);
                }
            }
            _con.SaveChanges();

            return Redirect("ListMummies");
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

        public IActionResult CreateDental(int gamous)
        {

            GamousDental g = new GamousDental() { };
            g.Gamous = gamous;
            _con.GamousDentals.Add(g);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousDentals", new { gamous = gamous });

        }

        public IActionResult CreateCranial(string locationID)
        {

            GamousCranial gc = new GamousCranial() { };
            gc.LocationId = locationID;
            _con.GamousCranials.Add(gc);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousCranials", new { locationId = locationID });

        }

        public IActionResult CreateC14(string loctionID)
        {

            GamousC14 gc = new GamousC14() { };
            gc.LoctionId = loctionID;
            _con.GamousC14s.Add(gc);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousC14", new { locationId = loctionID });

        }

        public IActionResult CreateBone(int gamous)
        {
            GamousBone g = new GamousBone() { };
            g.Gamous = gamous;
            _con.GamousBones.Add(g);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousBones", new { gamous = gamous });

        }

        public IActionResult CreateBioSample(string locationID)
        {

            GamousBiologicalSample gc = new GamousBiologicalSample() { };
            gc.LocationId = locationID;
            _con.GamousBiologicalSamples.Add(gc);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousBiologicalSamples", new { locationId = locationID });

        }

        public IActionResult CreateSamples(int gamous)
        {

            GamousSample g = new GamousSample() { };
            g.Gamous = gamous;
            _con.GamousSamples.Add(g);
            _con.SaveChanges();

            return RedirectToAction("Edit", "GamousSamples", new { gamous = gamous });

        }

        public IActionResult CreateFieldMains(string locationID)
        {

            FieldMain gc = new FieldMain() { };
            gc.LocationId = locationID;
            _con.FieldMains.Add(gc);
            _con.SaveChanges();

            return RedirectToAction("Edit", "FieldMains", new { locationId = locationID });

        }


        public IActionResult CreateFLocation(string locationID)
        {

            FieldLocation gc = new FieldLocation() { };
            gc.LocationId = locationID;
            _con.FieldLocations.Add(gc);
            _con.SaveChanges();

            return RedirectToAction("Edit", "FieldLocations", new { locationId = locationID });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
