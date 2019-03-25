using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class Role
    {   
        [Required]
        public int RoleId { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        
    }
}