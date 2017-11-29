using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public interface IUserManager
    {
        List<Repository.UsersQuery_Result> GetUsers(string FilterAccess, string FilterRol);

        string PostRole(string description);

        string PostAccess(string description);

        string PostUser(User user);

        string PostAccessXRole(string access, string role);

        List<Access> GetAccess(int roleFilter);

        List<Role> GetRoles();
        string DeleteUser(int userID);
        User ValidateUser(string name);
    }
}
