using IP_Booking_Overtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IP_BusinessLayer
{
    public class OvertimeManager : IOvertimeManager
    {
        private IndividualProject_DatabaseContext _db;

        public OvertimeManager()
        {
            _db = new IndividualProject_DatabaseContext();
        }

        public OvertimeManager(IndividualProject_DatabaseContext databaseContext)
        {
            _db = databaseContext;
        }

        public Overtime SelectedOvertime { get; set; }
        public void CreateOvertime(string day, TimeSpan startTime, string numberOfHours)
        {
            var newOvertime = new Overtime() { Day = day, StartTime = startTime, NumberOfHours = Convert.ToInt32(numberOfHours) };
            _db.Overtime.Add(newOvertime);
            _db.SaveChanges();
        }

        public void GetSelectedOvertime(object selectedOvertime)
        {
            SelectedOvertime = (Overtime)selectedOvertime;
        }

        public List<Overtime> PopulateAvailabelOvertime()
        {
            var available = _db.Overtime.Where(o => o.UserId == null);
            return available.ToList();
        }

        public List<Overtime> PopulateBookedOvertime(Users userEntered)
        {
            var overtime = _db.Overtime.Where(o => o.UserId == userEntered.UserId);
            return overtime.ToList();
        }

        public List<Overtime> PopulateBookedOvertimeForAllUsers()
        {
            var overtime = _db.Overtime.Where(o => o.UserId != null);
            return overtime.ToList();
        }

        public List<Overtime> PopulateOvertimeForFriday()
        {
            var overtime = _db.Overtime.Where(o => o.Day == "Friday" && o.UserId == null);
            return overtime.ToList();
        }

        public List<Overtime> PopulateOvertimeForMonday()
        {
            var overtime = _db.Overtime.Where(o => o.Day == "Monday" && o.UserId == null);
            return overtime.ToList();
        }

        public List<Overtime> PopulateOvertimeForThursday()
        {
            var overtime = _db.Overtime.Where(o => o.Day == "Thursday" && o.UserId == null);
            return overtime.ToList();
        }

        public List<Overtime> PopulateOvertimeForTuesday()
        {
            var overtime = _db.Overtime.Where(o => o.Day == "Tuesday" && o.UserId == null);
            return overtime.ToList();
        }

        public List<Overtime> PopulateOvertimeForWednesday()
        {
            var overtime = _db.Overtime.Where(o => o.Day == "Wednesday" && o.UserId == null);
            return overtime.ToList();
        }

        public void RemoveUser_IDs_FromBookedOvertime(object selectedOvertime)
        {
            GetSelectedOvertime(selectedOvertime);
            SelectedOvertime.UserId = null;
            _db.SaveChanges();
        }

        public void SetUser_IDs_ForBookedOvertime(Users enteredUser, object selectedOvertime)
        {
            GetSelectedOvertime(selectedOvertime);
            SelectedOvertime.UserId = enteredUser.UserId;
            _db.SaveChanges();
        }

        public bool CheckForOverlap(Users enteredUser, object selectedOvertime)
        {
            GetSelectedOvertime(selectedOvertime);
            var selectedOvertime_EndTime = SelectedOvertime.StartTime + TimeSpan.Parse($"{SelectedOvertime.NumberOfHours}:00");
            var bookedOvertimes = _db.Overtime.Where(o => o.UserId == enteredUser.UserId);
            var canBook = true;
            if (bookedOvertimes.Count() > 0)
            {
                TimeSpan? bookedOvertimeSlotEndTime;
                foreach (var bookedOvertimeSlot in bookedOvertimes)
                {
                    bookedOvertimeSlotEndTime = bookedOvertimeSlot.StartTime + TimeSpan.Parse($"{bookedOvertimeSlot.NumberOfHours}:00");
                    if (bookedOvertimeSlotEndTime < SelectedOvertime.StartTime)
                    {
                        if (!(bookedOvertimeSlotEndTime < SelectedOvertime.StartTime && bookedOvertimeSlot.StartTime < selectedOvertime_EndTime) && bookedOvertimeSlot.Day == SelectedOvertime.Day)
                        {
                            canBook = false;
                        }
                    }
                    else if (bookedOvertimeSlotEndTime > SelectedOvertime.StartTime)
                    {
                        if (!(bookedOvertimeSlotEndTime > SelectedOvertime.StartTime && bookedOvertimeSlot.StartTime > selectedOvertime_EndTime) && bookedOvertimeSlot.Day == SelectedOvertime.Day)
                        {
                            canBook = false;
                        }
                    }
                }
                if (canBook)
                {
                    SetUser_IDs_ForBookedOvertime(enteredUser, selectedOvertime);
                }
            }
            else if (bookedOvertimes.Count() == 0)
            {
                SetUser_IDs_ForBookedOvertime(enteredUser, selectedOvertime);
            }
            return canBook;
        }
    }
}
