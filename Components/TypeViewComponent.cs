using Intex_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Components
{
    public class TypeViewComponent : ViewComponent
    {
        private postgresContext _con;

        public TypeViewComponent(postgresContext c)
        {
            _con = c;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["type"];

            return View(_con.FileRecords
                .Select(x => x.Type)
                .Distinct());
        }
    }
}
