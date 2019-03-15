using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.ViewModels
{
    public class AdminIndexViewModel
    {
       public IEnumerable<UserViewModel> Users { get; set; }
       public PageInfo PageInfo { get; set; }
    }
}