using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intex_2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intex_2.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _con;

        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, ApplicationDbContext con)
        {
            this.roleManager = roleManager;
            _con = con;
        }

        public IActionResult Admin()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        public IActionResult ManageUsers()
        {
            ViewBag.users = _con.Users;
            return View();
        }


    }
}
