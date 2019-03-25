using System.Collections.Generic;

namespace WeatherApp.ViewModels
{
    public class AdminIndexViewModel
    {
       public IEnumerable<UserViewModel> Users { get; set; }
       public PageInfo PageInfo { get; set; }
    }
}