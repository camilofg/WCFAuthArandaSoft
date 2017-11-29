using BusinessLogic;
using CommonEntities;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Repository.Models.UserManager;

namespace WCFArandaSoftAuthService.Facade
{
    public class ManagerFacade
    {
        private readonly UserLogic userLogic;

        public ManagerFacade()
        {
            this.userLogic = new UserLogic(new UserManager());
        }

        public List<Repository.UsersQuery_Result> UserManager(string FilterAccess, string FilterRol)
        {
            return userLogic.GetUsers(FilterAccess, FilterRol);
        }

        public string RoleManager(string RoleDesc)
        {
            return userLogic.PostRole(RoleDesc);
        }

        public string AccessManager(string description)
        {
            return userLogic.PostAccess(description);
        }

        public string UserManager(RequestUser user)
        {
            var us = new Repository.User();
            us.Name = user.Name;
            us.PasswordHash = user.PasswordHash;
            us.TypeRoleID = user.TypeRoleID;
            return userLogic.PostUser(user);
        }

        public string AccessManager(string access, string role)
        {
            return userLogic.PostAccessXRole(access, role);
        }

        public List<Repository.Access> AccessManager(int roleFilter)
        {
            return userLogic.GetAccess(roleFilter);
        }

        public List<Repository.Role> RoleManager()
        {
            return userLogic.GetRoles();
        }

        public string UserManager(int userID)
        {
            return userLogic.DeleteUser(userID);
        }

        public string ValidateManager(string password, string name)
        {
            return userLogic.ValidateUser(password, name);
        }
    }
}