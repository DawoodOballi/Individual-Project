using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using IP_Booking_Overtime;
using Microsoft.Data.SqlClient;

namespace IP_BusinessLayer
{
    public class CRUDoperations
    {
        public Users EnteredUser { get; set; }
        public List<Users> RetrieveUsers()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        public Users GetUserForUserName(string enteredUser)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Users.Where(u => u.UserName == enteredUser).FirstOrDefault();
                return user;
            }
        }
    }
}
