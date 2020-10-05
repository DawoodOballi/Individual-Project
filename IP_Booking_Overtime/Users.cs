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
        public int? AdminId { get; set; }

        public virtual Admins Admin { get; set; }
        public virtual ICollection<Overtime> Overtime { get; set; }
    }
}
