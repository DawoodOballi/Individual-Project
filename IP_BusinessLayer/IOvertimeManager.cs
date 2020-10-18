using IP_Booking_Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer
{
    interface IOvertimeManager
    {
        public void CreateOvertime(string day, TimeSpan startTime, string numberOfHours);
        public void GetSelectedOvertime(object selectedOvertime);
        public void SetUser_IDs_ForBookedOvertime(Users enteredUser, object selectedOvertime);
        public void RemoveUser_IDs_FromBookedOvertime(object selectedOvertime);
        public List<Overtime> PopulateOvertimeForMonday();
        public List<Overtime> PopulateOvertimeForTuesday();
        public List<Overtime> PopulateOvertimeForWednesday();
        public List<Overtime> PopulateOvertimeForThursday();
        public List<Overtime> PopulateOvertimeForFriday();
        public List<Overtime> PopulateBookedOvertime(Users userEntered);
        public List<Overtime> PopulateBookedOvertimeForAllUsers();
        public List<Overtime> PopulateAvailabelOvertime();
        public bool CheckForOverlap(Users enteredUser, object selectedOvertime);
    }
}
