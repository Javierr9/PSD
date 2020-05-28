using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Factories
{
    public class UserFactory
    {
        public User CreteUser(string email, string name, string password, string gender, int roleId, string status)
        {
            User newUser = new User()
            {
                RoleID = roleId,
                Email = email,
                Name = name,
                Password = password,
                Gender = gender,
                Status = status
            };
            return newUser;
        }
    }
}