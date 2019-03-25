using System;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WorldController : Controller
    {

        public ActionResult Index()
        {
            using (var db = new UserContext())
            {
                var countries = db.Countries.Include("Cities").ToList();

                var countriesName = countries.Select(x => x.Name).ToArray();

                Array.Sort(countriesName);

                return View(countriesName);
            }
        }

        public JsonResult GetAllCities(string country)
        {
            using (var db = new UserContext())
            {   

                var cities = (db.Countries.Include("Cities").FirstOrDefault(c => c.Name == country).Cities).Select(c=>c.Name).ToArray();

                Array.Sort(cities);

                return Json(cities, JsonRequestBehavior.AllowGet);
            } 

        }

        public JsonResult GetImgURL(string city)
        {
            using (var db = new UserContext())
            {   
                var cityImgURL = db.Cities.FirstOrDefault(c => c.Name == city).ImageURL;

                if (cityImgURL != null)
                {
                    return Json(cityImgURL, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("null", JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}