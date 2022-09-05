using System.Collections.Generic;
using AuthorizeModule.Models;
using AuthorizeModule.Repository;

namespace AuthorizeModule.Repository
{
    public class AuthRepo : IAuthRepo
    {
        public List<User> Users()
        {
            List<User> userObj = new List<User>();
            userObj.Add(new User { EmployeeId = 101, Password = "123456" });
            userObj.Add(new User { EmployeeId = 102, Password = "123456" });
            userObj.Add(new User { EmployeeId = 103, Password = "123456" });
            userObj.Add(new User { EmployeeId = 104, Password = "123456" });
            return userObj;
        }


    }
}
