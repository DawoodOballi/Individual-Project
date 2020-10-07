using System;
using System.Collections.Generic;
using System.Text;

namespace IP_Booking_Overtime
{
    public partial class Overtime
    {
        public override string ToString()
        {
            string overtime = "ID: " + UserId + " | Day: " + Day + " | Hours: " + NumberOfHours + " | Start time: " + DtStartDdmmmyyyy;
            return overtime;
        }
    }
}

