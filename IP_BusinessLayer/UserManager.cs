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
            GetUserForUserName(enteredUserName);
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

        public Users GetUserForUserName(string enteredUserNamer)

        {
            return EnteredUser = _db.Users.Where(u => u.UserName == enteredUserNamer).FirstOrDefault();
        }

        public void RemoveUser(string enteredUserName)
        {
            GetUserForUserName(enteredUserName);
            if (EnteredUser != null)
            {
                _db.Users.Remove(EnteredUser);
                _db.SaveChanges();
            }
        }

        public List<Users> RetrieveUsers()
        {
            return _db.Users.ToList();
        }
    }
}
