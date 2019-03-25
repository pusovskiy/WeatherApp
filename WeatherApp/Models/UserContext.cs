using System.Data.Entity;

namespace WeatherApp.Models
{
    public class UserContext: DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}