using Intex_2.Models;
using Intex_2.Models.ViewModels;
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

        public IActionResult DetailsMummies(string loc)
        {
            GamousMain g = _con.GamousMains.FirstOrDefault(p => p.LocationId == loc);

            return View(new MummyDetailsViewModel
            {
                mummy = _con.GamousMains
                    .Where(p => p.LocationId == loc)

            }) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
