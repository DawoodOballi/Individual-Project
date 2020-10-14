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
        public Admins EnteredAdmin { get; set; }
        public Overtime EntTime { get; set; }
        public List<Users> RetrieveUsers()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        private IndividualProject_DatabaseContext _dbContext;

        public CRUDoperations() {
            _dbContext = new IndividualProject_DatabaseContext();
        }

        public CRUDoperations(IndividualProject_DatabaseContext db)
        {
            _dbContext = db;
        }

        public void Create(string enteredUserName)
        {
                EnteredUser = _dbContext.Users.Where(u => u.UserName == enteredUserName).FirstOrDefault();
                if(EnteredUser == null)
                {
                    Users newUser = new Users { UserName = enteredUserName };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
        }

        public void CreateOvertime(string day, TimeSpan startTime, string numberOfHours)
        {
            var newOvertime = new Overtime() { Day = day, StartTime = startTime, NumberOfHours = Convert.ToInt32(numberOfHours) };
            using (var db = new IndividualProject_DatabaseContext())
            {
                db.Overtime.Add(newOvertime);
                db.SaveChanges();
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

        public Admins GetAdmin(string enteredAdmin)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var admin = db.Admins.Where(a => a.AdminName == enteredAdmin).FirstOrDefault();
                EnteredAdmin = admin;
                return EnteredAdmin;
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
                SelectedOvertime = db.Overtime.Where(o => o.OvertimeId == SelectedOvertime.OvertimeId).FirstOrDefault();
                SelectedOvertime.UserId = enteredUser.UserId;
                db.SaveChanges();
            };
        }

        public void RemoveUser_IDs()
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

        public List<Overtime> PopulateBookedOvertimeForAllUsers()
        {
            using(var db = new IndividualProject_DatabaseContext())
            {
                var users = db.Overtime.Where(o => o.UserId != null);
                return users.ToList();
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

        public bool CheckForOverlap(Users enteredUser, object selectedOvertime)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var end = SelectedOvertime.StartTime + TimeSpan.Parse($"{SelectedOvertime.NumberOfHours}:00");
                var bookedOvertimes = db.Overtime.Where(o => o.UserId == enteredUser.UserId);
                var canBook = true;
                if (bookedOvertimes.Count() > 0)
                {
                    TimeSpan? overtimeSlotEndTime;
                    foreach (var overtimeSlot in bookedOvertimes)
                    {
                        overtimeSlotEndTime = overtimeSlot.StartTime + TimeSpan.Parse($"{overtimeSlot.NumberOfHours}:00");
                        if (overtimeSlotEndTime < SelectedOvertime.StartTime)
                        {
                            if (!(overtimeSlotEndTime < SelectedOvertime.StartTime && overtimeSlot.StartTime < end) && overtimeSlot.Day == SelectedOvertime.Day)
                            {
                                canBook = false;
                            }
                        }
                        else if(overtimeSlotEndTime > SelectedOvertime.StartTime)
                        {
                            if (!(overtimeSlotEndTime > SelectedOvertime.StartTime && overtimeSlot.StartTime > end) && overtimeSlot.Day == SelectedOvertime.Day)
                            {
                                canBook = false;
                            }
                        }
                    }
                    if (canBook)
                    {
                        SetUser_IDs(enteredUser);
                    }
                }
                else if (bookedOvertimes.Count() == 0)
                {
                    SetUser_IDs(enteredUser);
                }
                return canBook;
            }
        }

        public bool Overlaps(Users enteredUser, object selectedOvertime)
        {
            bool overlaps;
            GetOvertime(selectedOvertime);
            return CheckForOverlap(enteredUser, selectedOvertime) ? overlaps = true : overlaps = false;
        }
    }
}
