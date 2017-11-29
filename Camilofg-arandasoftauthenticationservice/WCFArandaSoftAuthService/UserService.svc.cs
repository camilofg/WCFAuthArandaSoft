using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repository;
using WCFArandaSoftAuthService.Facade;
using CommonEntities;

namespace WCFArandaSoftAuthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly ManagerFacade facade;

        public UserService()
        {
            this.facade = new ManagerFacade();
        }

        public List<UsersQuery_Result> GetUsers(string FilterAccess = "", string FilterRol = "")
        {
            return facade.UserManager(FilterAccess == "null" ? "" : FilterAccess, FilterRol == "null" ? "" : FilterRol);
        }

        public ResponseData PostAccess(RequestData AccessDescription)
        {
            var response = new ResponseData();
            response.Message = facade.AccessManager(AccessDescription.Description);
            return response;
        }

        public ResponseData PostRole(RequestData roleDesc)
        {
            var response = new ResponseData();
            response.Message = facade.RoleManager(roleDesc.Description);
            return response;
        }

        public ResponseData PostAccessXRole(RequestAccessXRole AccessDes)
        {
            var response = new ResponseData();
            response.Message = facade.AccessManager(AccessDes.Access, AccessDes.Rol);
            return response;
        }

        public ResponseData PostUser(RequestUser user)
        {
            var response = new ResponseData();
            response.Message = facade.UserManager(user);
            return response;
        }

        public List<Role> GetRoles()
        {
            var response = facade.RoleManager();
            return response;
        }

        public List<Access> GetAccess(string roleFiltered)
        {
            var response = facade.AccessManager(Convert.ToInt32(roleFiltered));
            return response;
        }

        public ResponseData DeleteUser(string userID)
        {
            var response = new ResponseData();
            response.Message = facade.UserManager(Convert.ToInt32(userID));
            return response;
        }

        public ResponseData PostValidateUser(RequestUser user)
        {
            var response = new ResponseData();
            response.Message = facade.ValidateManager(user.PasswordHash, user.Name);
            return response;
        }
    }
}
