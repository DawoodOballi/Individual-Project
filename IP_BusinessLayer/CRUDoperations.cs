using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using IP_Booking_Overtime;
using IP_BusinessLayer;
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

        private IndividualProject_DatabaseContext _db;

        public CRUDoperations() {
            _db = new IndividualProject_DatabaseContext();
        }

        public CRUDoperations(IndividualProject_DatabaseContext db)
        {
            _db = db;
        }

        public void CreateUsers(List<Users> list)
        {
            _db.Users.AddRange(list);
            _db.SaveChanges();
        }

        public void Create(string enteredUserName)
        {
                EnteredUser = _db.Users.Where(u => u.UserName == enteredUserName).FirstOrDefault();
                if(EnteredUser == null)
                {
                    Users newUser = new Users { UserName = enteredUserName };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();
                }
        }

        public void AddUser(Users user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void CreateOvertime(string day, TimeSpan startTime, string numberOfHours)
        {
            var newOvertime = new Overtime() { Day = day, StartTime = startTime, NumberOfHours = Convert.ToInt32(numberOfHours) };
                _db.Overtime.Add(newOvertime);
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
            if(user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public Admins GetAdmin(string enteredAdmin)
        {
                var admin = _db.Admins.Where(a => a.AdminName == enteredAdmin).FirstOrDefault();
                EnteredAdmin = admin;
                return EnteredAdmin;
        }

        public void GetOvertime(object selectedOvertime)
        {
            SelectedOvertime = (Overtime)selectedOvertime;
        }

        public void SetUser_IDs(Users enteredUser)
        {
                SelectedOvertime = _db.Overtime.Where(o => o.OvertimeId == SelectedOvertime.OvertimeId).FirstOrDefault();
                SelectedOvertime.UserId = enteredUser.UserId;
                _db.SaveChanges();
        }

        public void RemoveUser_IDs()
        {
                SelectedOvertime = _db.Overtime.Where(o => o.OvertimeId == SelectedOvertime.OvertimeId).FirstOrDefault();
                SelectedOvertime.UserId = null;
                _db.SaveChanges();
        }

        public List<Overtime> PopulateOvertimeForMonday()
        {
                var user = _db.Overtime.Where(o => o.Day == "Monday" && o.UserId == null);
                return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForTuesday()
        {
                var user = _db.Overtime.Where(o => o.Day == "Tuesday" && o.UserId == null);
                return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForWednesday()
        {
                var user = _db.Overtime.Where(o => o.Day == "Wednesday" && o.UserId == null);
                return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForThursday()
        {
                var user = _db.Overtime.Where(o => o.Day == "Thursday" && o.UserId == null);
                return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForFriday()
        {
                var user = _db.Overtime.Where(o => o.Day == "Friday" && o.UserId == null);
                return user.ToList();
        }

        public List<Overtime> PopulateBookedOvertime(Users userEntered)
        {
                var user = _db.Overtime.Where(o => o.UserId == userEntered.UserId);
                return user.ToList();
        }

        public List<Overtime> PopulateBookedOvertimeForAllUsers()
        {
                var users = _db.Overtime.Where(o => o.UserId != null);
                return users.ToList();
        }

        public List<Overtime> PopulateAvailabelOvertime()
        {
                var available = _db.Overtime.Where(o => o.UserId == null);
                return available.ToList();
        }

        public bool CheckForOverlap(Users enteredUser, object selectedOvertime)
        {
                var end = SelectedOvertime.StartTime + TimeSpan.Parse($"{SelectedOvertime.NumberOfHours}:00");
                var bookedOvertimes = _db.Overtime.Where(o => o.UserId == enteredUser.UserId);
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

        public bool Overlaps(Users enteredUser, object selectedOvertime)
        {
            GetOvertime(selectedOvertime);
            return CheckForOverlap(enteredUser, selectedOvertime) ?true : false;
        }
    }
}
