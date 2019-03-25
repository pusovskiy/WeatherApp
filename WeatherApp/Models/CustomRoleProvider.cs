using System;
using System.Linq;
using System.Web.Security;

namespace WeatherApp.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            using (UserContext db = new UserContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == username);

                var roles = from ur in user.Roles
                            from r in db.Roles
                            where ur.RoleId == r.RoleId
                            select r.Name;
                if (user != null)
                    return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
                else
                    return false;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (UserContext db = new UserContext())
            {
                var user = db.Users.Include("Roles").FirstOrDefault(u => u.Email == username);
                var roles = user.Roles;

                if (roles != null)
                {
                    return roles.Select(x => x.Name).ToArray();
                }
                else
                {
                    return new string[] { };
                };

            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}