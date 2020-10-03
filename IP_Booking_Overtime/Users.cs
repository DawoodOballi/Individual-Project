using System;
using System.Collections.Generic;

namespace IP_Booking_Overtime
{
    public partial class Users
    {
        public Users()
        {
            Overtime = new HashSet<Overtime>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Overtime> Overtime { get; set; }
    }
}
