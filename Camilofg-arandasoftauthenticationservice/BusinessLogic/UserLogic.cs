using CommonEntities;
using Newtonsoft.Json;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserManager manager;

        public UserLogic(IUserManager manager)
        {
            this.manager = manager;
        }

        public List<Repository.UsersQuery_Result> GetUsers(string FilterAccess, string FilterRol)
        {
            var result = manager.GetUsers(FilterAccess, FilterRol);
            return result;
        }

        public string PostRole(string description)
        {
            return manager.PostRole(description);
        }

        public string PostAccess(string description)
        {
            return manager.PostAccess(description);
        }

        public string PostUser(RequestUser user)
        {
            var passManager = new PasswordManager();
            List<string> passHashed = passManager.GeneratePassword(user.PasswordHash, 36);
            user.PasswordHash = passHashed[1];
            user.SecuritySalt = passHashed[0];
            var userConverted = JsonConvert.DeserializeObject<Repository.User>(JsonConvert.SerializeObject(user));
            return manager.PostUser(userConverted);
        }

        public string PostAccessXRole(string access, string role)
        {
            return manager.PostAccessXRole(access, role);
        }

        public string DeleteUser(int userID)
        {
            return manager.DeleteUser(userID);
        }

        public List<Repository.Access> GetAccess(int roleFilter)
        {
            return manager.GetAccess(roleFilter);
        }

        public List<Repository.Role> GetRoles()
        {
            return manager.GetRoles();
        }

        public string ValidateUser(string password, string name)
        {
            var user = manager.ValidateUser(name);
            var passManager = new PasswordManager();
            string passHashed = passManager.GenerateSHA256Hash(password, user.SecuritySalt);
            if (user.PasswordHash == passHashed)
                return "Valid User";
            else
                return "Invalid User";
        }
    }
}
