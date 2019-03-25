using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public string GetWeather()
        {
            using (UserContext db = new UserContext())
            {
                string city = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name).City;

                string url =
                    $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID=a431728ee71691e171014a5010f5a08e";

                return url;
                }
               

            }  
        }
    }
