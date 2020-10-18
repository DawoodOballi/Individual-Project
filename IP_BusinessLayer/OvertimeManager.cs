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
            throw new NotImplementedException();
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
            var user = _db.Overtime.Where(o => o.UserId == userEntered.UserId);
            return user.ToList();
        }

        public List<Overtime> PopulateBookedOvertimeForAllUsers()
        {
            var users = _db.Overtime.Where(o => o.UserId != null);
            return users.ToList();
        }

        public List<Overtime> PopulateOvertimeForFriday()
        {
            var user = _db.Overtime.Where(o => o.Day == "Friday" && o.UserId == null);
            return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForMonday()
        {
            var user = _db.Overtime.Where(o => o.Day == "Monday" && o.UserId == null);
            return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForThursday()
        {
            var user = _db.Overtime.Where(o => o.Day == "Thursday" && o.UserId == null);
            return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForTuesday()
        {
            var user = _db.Overtime.Where(o => o.Day == "Tueday" && o.UserId == null);
            return user.ToList();
        }

        public List<Overtime> PopulateOvertimeForWednesday()
        {
            var user = _db.Overtime.Where(o => o.Day == "Wednesday" && o.UserId == null);
            return user.ToList();
        }

        public void RemoveUser_IDs_FromBookedOvertime(object selectedOvertime)
        {
            GetSelectedOvertime(selectedOvertime);
            SelectedOvertime.UserId = null;
            _db.SaveChanges();
        }

        public void SetUser_IDs_ForBookedOvertime(Users enteredUser)
        {
            GetSelectedOvertime(SelectedOvertime);
            SelectedOvertime.UserId = enteredUser.UserId;
            _db.SaveChanges();
        }
    }
}
