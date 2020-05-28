using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Models;

namespace TokoBeDia.Repositories
{
    public class UserRepository : IUserRepository
    {
        TokoBeDiaEntities db = new TokoBeDiaEntities();

        public void InsertUser(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public User GetUserByEmailAndPass(string email, string password)
        {
            User check = db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return check;
        }

        public User GetUserByEmail(string email)
        {
            User data = db.Users.Where(x => x.Email == email).FirstOrDefault();
            return data;
        }

        public void UpdateUser(User newData, string currentEmail)
        {
            User oldData = db.Users.Where(x => x.Email == currentEmail).FirstOrDefault();

            oldData.Email = newData.Email;
            oldData.Name = newData.Name;
            oldData.Gender = newData.Gender;
            db.SaveChanges();
        }

        public void UpdatePassword(User user, string newPassword)
        {
            User data = db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            data.Password = newPassword;
            db.SaveChanges();
        }
        public List<User> GetAllUser()
        {
            List<User> allUser = db.Users.ToList();
            return allUser;
        }

        public void UpdateStatus(int ID, string newStatus)
        {
            User data = db.Users.Where(x => x.ID == ID).FirstOrDefault();
            data.Status = newStatus;
            db.SaveChanges();
        }
        public void UpdateRole(int ID, int newRoleId)
        {
            User data = db.Users.Where(x => x.ID == ID).FirstOrDefault();
            data.RoleID = newRoleId;
            db.SaveChanges();
        }
        public bool GetSameEmailInsert(string email)
        {
            bool check = db.Users.Any(x => x.Email == email);
            return check;
        }
    }
}