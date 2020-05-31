using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;
using TokoBeDia.Repositories;

namespace TokoBeDia.Handlers
{
    public class UserHandler
    {
        public void InsertUser(User newUser)
        {
            new UserRepository().InsertUser(newUser);
        }

        public User GetUserByEmailAndPass(string email, string password)
        {
            return new UserRepository().GetUserByEmailAndPass(email, password);
        }

        public User GetUserByEmail(string email)
        {
            return new UserRepository().GetUserByEmail(email);
        }

        public void UpdateUser(User newData, string currentEmail)
        {
            new UserRepository().UpdateUser(newData, currentEmail);
        }

        public void UpdatePassword(User user, string newPassword)
        {
            new UserRepository().UpdatePassword(user, newPassword);
        }
        public List<User> GetAllUser()
        {
            return new UserRepository().GetAllUser();
        }

        public void UpdateStatus(int ID, string newStatus)
        {
            new UserRepository().UpdateStatus(ID, newStatus);
        }
        public void UpdateRole(int ID, int newRoleId)
        {
            new UserRepository().UpdateRole(ID, newRoleId);
        }
        public bool GetSameEmailInsert(string email)
        {
            return new UserRepository().GetSameEmailInsert(email);
        }
    }
}