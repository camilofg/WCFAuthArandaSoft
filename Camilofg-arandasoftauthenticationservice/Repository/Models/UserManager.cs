using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserManager : IUserManager
    {
        private AuthenticacionRepository DB = new AuthenticacionRepository();

        public List<Repository.UsersQuery_Result> GetUsers(string FilterAccess, string FilterRol)
        {
            var algo = DB.UsersQuery(FilterAccess, FilterRol).ToList();
            return algo;
        }

        public string PostAccess(string description)
        {
            if (DB.Access.Where(x => x.Description == description).Count() == 0)
            {
                var access = new Repository.Access();
                access.Description = description;
                DB.Access.Add(access);
                DB.SaveChanges();
                return "save correctly";
            }
            return "the Access already exist";
        }

        public string PostRole(string description)
        {
            if (DB.Role.Where(x => x.Description == description).Count() == 0)
            {
                var role = new Repository.Role();
                role.Description = description;
                DB.Role.Add(role);
                DB.SaveChanges();
                return "save correctly";
            }
            return "the Role already exist";
        }

        public string PostAccessXRole(string access, string role)
        {
            return DB.AssociateAccessXRole(access, role).First().ToString();
        }

        public string PostUser(User user)
        {
            if (DB.User.Where(x => x.Name == user.Name && x.Email == user.Email).Count() == 0)
            {
                try
                {
                    DB.User.Add(user);
                    DB.SaveChanges();
                    return "save correctly";
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return "the user already exist";
        }

        public List<Access> GetAccess(int roleFilter)
        {
            return JsonConvert.DeserializeObject<List<Access>>(JsonConvert.SerializeObject(DB.GetAccessXRole(roleFilter)));

        }

        public List<Role> GetRoles()
        {
            return DB.Role.ToList();
        }

        public string DeleteUser(int userID)
        {
            try
            {
                var user = new User { UserID = userID };
                DB.User.Attach(user);
                DB.User.Remove(user);
                DB.SaveChanges();
                return "User erased correctly";
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public User ValidateUser(string name) {
            var users = (from u in DB.User where u.Name == name select u).ToList();
            if (users.Count == 0)
                return new User();
            return DB.User.Where(x => x.Name == name).First();
        }
    }
}
