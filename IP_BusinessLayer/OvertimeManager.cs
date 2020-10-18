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

        public void SetUser_IDs_ForBookedOvertime(Users enteredUser)
        {
            //GetSelectedOvertime(SelectedOvertime);
            SelectedOvertime.UserId = enteredUser.UserId;
            _db.SaveChanges();
        }
    }
}
