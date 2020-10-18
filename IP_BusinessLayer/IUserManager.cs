using IP_Booking_Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer
{
    interface IUserManager
    {
        public List<Users> RetrieveUsers();
        public void CreateUsers(List<Users> list);
        public void CreateUser(string enteredUserName);
        public void AddUser(Users user);
        public Users GetUserForUserName(string enteredUser);
        public void RemoveUser(string name);
    }
}
