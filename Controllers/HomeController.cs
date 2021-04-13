﻿using Intex_2.Models;
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
                return View("MediaLibrary");
            }
            else
            {
                return View("UploadMedia");
            }
        }
     
        public IActionResult MediaLibrary()
        {
            var files = _con.FileRecords;
           
                return View(new MediaViewModel
                {
                    files = files
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
        public IActionResult OsteologyForm()
        {
            return View(new MummyDetailsViewModel { });
        }

        [Authorize]
        [HttpPost]
        public IActionResult OsteologyForm(GamousLocation location, GamousMain mummy, GamousBone bones, GamousDental dental, GamousSample sample)
        {
           string id = location.LowPairNs + location.BurialLocationNs + location.LowPairEw + location.BurialLocationEw + location.BurialSubplot + location.BurialNumber;
            int gid = (int)(_con.GamousMains.Select(x => x.Gamous).Max() + 1);

            location.LocationId = id;
            mummy.LocationId = id;
            mummy.Gamous = gid;
            bones.Gamous = gid;
            dental.Gamous = gid;
            sample.Gamous = gid;
            

            _con.GamousLocations.Add(location);
            _con.GamousMains.Add(mummy);
            _con.GamousBones.Add(bones);
            _con.GamousDentals.Add(dental);
            _con.GamousSamples.Add(sample);
            _con.SaveChanges();

            return RedirectToAction("OsteologyForm");
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
