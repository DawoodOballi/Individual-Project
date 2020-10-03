using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using IP_Booking_Overtime;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IP_BusinessLayer
{
    public class CRUDoperations
    {
        public Users EnteredUser { get; set; }
        public Overtime SelectedOvertime { get; set; }
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
                return EnteredUser;
            }
        }

        public void GetOvertime(object selectedOvertime)
        {
            SelectedOvertime = (Overtime)selectedOvertime;
        }

        public void UpdateUserID(Users enteredUser)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                SelectedOvertime = db.Overtime.Where(o => o.UserId == null).FirstOrDefault();
                SelectedOvertime.UserId = enteredUser.UserId;
                db.SaveChanges();
            }
        }

        public void SetUser_IDs(Users enteredUser, object selectedItem, int selectedItemIndex)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                if (selectedItem.ToString().Contains("Monday"))
                {
                    var query =
                        from overtime in db.Overtime.Include(u => u.User)
                        where overtime.Day == "Monday" && overtime.UserId == null
                        select overtime;
                    for(int i = 0; i < query.Count(); i++)
                    {
                        if (i == selectedItemIndex)
                        {
                            SelectedOvertime.UserId = enteredUser.UserId;
                            break;
                        }
                    }
                }
                db.SaveChanges();
            };
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
