using System;
using System.Collections.Generic;
using System.Text;

namespace IP_Booking_Overtime
{
    public partial class Overtime
    {
        public override string ToString()
        {
            return $"Day:{Day} | Hours:{NumberOfHours} | {StartTime}";
        }
    }
}
