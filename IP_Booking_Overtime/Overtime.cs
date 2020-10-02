using System;
using System.Collections.Generic;

namespace IP_Booking_Overtime
{
    public partial class Overtime
    {
        public int? UserId { get; set; }
        public string Day { get; set; }
        public int? NumberOfHours { get; set; }
        public TimeSpan? StartTime { get; set; }
        public string DtStartDdmmmyyyy { get; set; }

        public virtual Users User { get; set; }
    }
}
