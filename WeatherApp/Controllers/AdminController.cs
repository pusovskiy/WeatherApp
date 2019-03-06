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
    //[Authorize(Roles = "Admin")]
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
                        Id = user.Id,
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
    }
}