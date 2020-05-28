using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    interface IUserRepository
    {
        void InsertUser(User user);
        User GetUserByEmailAndPass(string email, string password);
        User GetUserByEmail(string email);
        void UpdateUser(User user, string currentEmail);
        void UpdatePassword(User user, string newPassword);
        List<User> GetAllUser();
        void UpdateStatus(int ID, string newStatus);
        void UpdateRole(int ID, int newRoleID);
        bool GetSameEmailInsert(string email);
    }
}
