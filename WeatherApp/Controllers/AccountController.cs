﻿using System;
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
        public string Login(LoginViewModel model)
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
                    return "You are successfully logged in.Refresh page";
                }

                return "Didn't found this user in db.Maybe register first.";
            }

            return "Wrong data";
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

            using (UserContext db = new UserContext())
            {
                
                    var user = db.Users.First(u => u.Email == User.Identity.Name);

                    var userViewModel = new UserViewModel
                    {   
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        City = user.City,
                        Country = user.Country
                    };

                    return View(userViewModel);

            }
        }
    }
}