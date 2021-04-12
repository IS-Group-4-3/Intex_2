using Intex_2.Models;
using Intex_2.Models.ViewModels;
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
        public int PageSize = 10;
        
        public HomeController(ILogger<HomeController> logger, postgresContext con)
        {
            _logger = logger;
            _con = con;
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

        public IActionResult Map()
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
                sample = gs

            }) ;
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
