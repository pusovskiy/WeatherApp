﻿using System.Collections.Generic;

namespace WeatherApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }

        

    }
}