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

        public void Create(string enteredUserName)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                EnteredUser = db.Users.Where(u => u.UserName == enteredUserName).FirstOrDefault();
                if(EnteredUser == null)
                {
                    Users newUser = new Users { UserName = enteredUserName };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
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

        public void SetUser_IDs(Users enteredUser)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                SelectedOvertime = db.Overtime.Include(u => u.User).Where(o => o.OvertimeId == SelectedOvertime.OvertimeId).FirstOrDefault();
                //if (SelectedOvertime.UserId == null)
                //{
                    SelectedOvertime.UserId = enteredUser.UserId;
                //}
                //else if(SelectedOvertime.UserId != null)
                //{
                //    SelectedOvertime.UserId = null;
                //}
                db.SaveChanges();
            };
        }

        public void RemoveUser_IDs(Users enteredUser)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                SelectedOvertime = db.Overtime.Where(o => o.OvertimeId == SelectedOvertime.OvertimeId).FirstOrDefault();
                SelectedOvertime.UserId = null;
                db.SaveChanges();
            }
        }

        public List<Overtime> PopulateOvertimeForMonday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Monday" && o.UserId == null);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForTuesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Tuesday" && o.UserId == null);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForWednesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Wednesday" && o.UserId == null);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForThursday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Thursday" && o.UserId == null);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateOvertimeForFriday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.Day == "Friday" && o.UserId == null);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateBookedOvertime(Users userEntered)
        {
            using(var db = new IndividualProject_DatabaseContext())
            {
                var user = db.Overtime.Where(o => o.UserId == userEntered.UserId);
                return user.ToList();
            }
        }

        public List<Overtime> PopulateAvailabelOvertime()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var available = db.Overtime.Where(o => o.UserId == null);
                return available.ToList();
            }
        }
    }
}
