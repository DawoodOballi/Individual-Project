using System;
using System.Collections.Generic;

namespace IP_Booking_Overtime
{
    public partial class Admins
    {
        public Admins()
        {
            Users = new HashSet<Users>();
        }

        public int AdminId { get; set; }
        public string AdminName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
