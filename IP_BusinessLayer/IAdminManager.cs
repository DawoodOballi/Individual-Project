using IP_Booking_Overtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer
{
    interface IAdminManager
    {
        public Admins GetAdmin(string enteredAdmin);
        public void CreateAdmin(string enteredAdminName);
        public void RemoveAdmin(string enteredAdmin);
        public void UpdateAdmin(Admins admin);
    }
}
