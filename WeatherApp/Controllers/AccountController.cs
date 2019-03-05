using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                }

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel m)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == m.Email);

                    if (user == null)
                    {
                        db.Users.Add(new User
                        {
                            Name = m.Name,
                            Surname = m.Surname,
                            Email = m.Email,
                            Password = m.Password,
                            Country = m.Country,
                            City = m.City
                        });
                        db.SaveChanges();

                        FormsAuthentication.SetAuthCookie(m.Email,true);
                        ViewBag.Message = "Successfully registred";
                    }
                    else
                    { 
                        ViewBag.Message = "This user in base";
                    }
                }

            }
            return View(m);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult UserProfile()
        {   

            return View();
        }
    }
}