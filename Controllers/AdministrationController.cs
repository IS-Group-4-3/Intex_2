using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intex_2.Data;
using Intex_2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intex_2.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ApplicationDbContext _con;

        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        ApplicationDbContext con)
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



            var results = (from u in _con.Users
                           join ur in _con.UserRoles on u.Id equals ur.UserId
                           join r in _con.Roles on ur.RoleId equals r.Id
                           select new UserViewModel()
                           {
                               id = u.Id,
                               email = u.Email,
                               role = r.Name
                           }).ToList();

            ViewBag.joined_users = results; 

            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            var user = _con.Users.Where(x => x.Id == id).FirstOrDefault();
            _con.Users.Remove(user);
            _con.SaveChanges();
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public IActionResult EditUserRole(string id, string role)
        {
            var role_id = _con.Roles
                .FromSqlInterpolated($"SELECT Id FROM Roles WHERE Name = {role}").ToString();

            var user_role = _con.UserRoles.Where(x => x.UserId == id).FirstOrDefault();

            //_con.UserRoles.Remove(user_role);
            //_con.SaveChanges();



            //_con.UserRoles.Add()

            user_role.RoleId = role_id;
            _con.SaveChanges();

            return RedirectToAction("ManageUsers");
        }
    }
}
