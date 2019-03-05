using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                        Name = user.Name,
                        Surname = user.Surname,
                        Country = user.Country,
                        City = user.City
                    });
                }

                return View(usersViewModels);
            }
        }
    }
}