using IP_Booking_Overtime.ExampleDBModel;
using IP_BusinessLayer.ExampleDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IP_BusinessLayer.MockBackEnd
{
    public class UserManager : IUserManager
    {
        private ExampleContext _db;

        public UserManager(ExampleContext dbContext)
        {
            _db = dbContext;
        }

        public virtual void AddUser(User item)
        {
            _db.User.Add(item);
            _db.SaveChanges();
        }

        public User FindUser(string name)
        {
            if (name == null || name == string.Empty) return null;
            name = name.ToLower();
            return _db.User.Where(u => u.UserName.ToLower().StartsWith(name)).FirstOrDefault();
        }

        public int GetUserId(string name)
        {
            if (name == null || name == string.Empty) return 0;
            name = name.ToLower();
            return _db.User.Where(u => u.UserName.ToLower() == name).Select(u => u.UserId).FirstOrDefault();
        }

        public void RemoveUser(string name)
        {
            var item = FindUser(name);
            if(item != null)
            {
                _db.User.Remove(item);
                _db.SaveChanges();
            }
        }

        public void CreateUsers(List<User> items)
        {
            _db.User.AddRange(items);
            _db.SaveChanges();
        }
    }
}
