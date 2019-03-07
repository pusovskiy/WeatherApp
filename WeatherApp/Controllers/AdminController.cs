using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{   
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {   
        public ActionResult Index()
        {
            using (UserContext db = new UserContext())
            {
                
                var users = db.Users.ToList();

                var usersViewModels = new List<UserViewModel>();

                foreach (var user in users)
                {
                    usersViewModels.Add(new UserViewModel
                    {   
                        Id = user.UserId,
                        Name = user.Name,
                        Surname = user.Surname,
                        Country = user.Country,
                        City = user.City
                    });
                }

                return View(usersViewModels);
            }
        }

        public ActionResult DeleteUser(int id)
        {
            using (UserContext db = new UserContext())
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult MakeUserAdmin(int id)
        {   
            
            using (var db = new UserContext())
            {
                var user = db.Users.Include("Roles").FirstOrDefault(u => u.UserId == id);

                var userRoles = user.Roles;

                //Add constraint in many-to-many table (1 - Admin)
                var role = db.Roles.FirstOrDefault(r => r.RoleId == 1);

                if (userRoles.Count == 0)
                {
                        user.Roles.Add(role);
                        db.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }
    }
}