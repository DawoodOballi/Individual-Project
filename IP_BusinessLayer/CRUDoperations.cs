using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SetEnteredUserEqualTo(object enteredUser)
        {
            EnteredUser = (Users)enteredUser;
        }
    }
}
