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
                EnteredUser = user;
                return user;
            }
        }

        public List<Overtime> PopulateOvertimeForMonday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Monday");
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForTuesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Tuesday");
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForWednesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Wednesday");
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForThursday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Thursday");
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForFriday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Friday");
                return user.ToList();
            }
        }
    }
}
