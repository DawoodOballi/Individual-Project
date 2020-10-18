using IP_Booking_Overtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IP_BusinessLayer
{
    public class UserManager : IUserManager
    {
        private IndividualProject_DatabaseContext _db;
        public Users EnteredUser { get; set; }

        public UserManager()
        {
            _db = new IndividualProject_DatabaseContext();
        }

        public UserManager(IndividualProject_DatabaseContext databaseContext)
        {
            _db = databaseContext;
        }
        public void AddUser(Users user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void CreateUser(string enteredUserName)
        {
            EnteredUser = _db.Users.Where(u => u.UserName == enteredUserName).FirstOrDefault();
            if (EnteredUser == null)
            {
                Users newUser = new Users { UserName = enteredUserName };
                _db.Users.Add(newUser);
                _db.SaveChanges();
            }
        }

        public void CreateUsers(List<Users> list)
        {
            _db.Users.AddRange(list);
            _db.SaveChanges();
        }

        public Users GetUserForUserName(string enteredUser)
        {
            var user = _db.Users.Where(u => u.UserName == enteredUser).FirstOrDefault();
            EnteredUser = user;
            return EnteredUser;
        }

        public void RemoveUser(string name)
        {
            var user = GetUserForUserName(name);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public List<Users> RetrieveUsers()
        {
            return _db.Users.ToList();
        }
    }
}
