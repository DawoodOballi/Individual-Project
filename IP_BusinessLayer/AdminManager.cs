using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using IP_Booking_Overtime;
using IP_BusinessLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IP_BusinessLayer
{
    public class AdminManager : IAdminManager
    {
        public Admins EnteredAdmin { get; set; }

        private IndividualProject_DatabaseContext _db;

        public AdminManager()
        {
            _db = new IndividualProject_DatabaseContext();
        }

        public AdminManager(IndividualProject_DatabaseContext db)
        {
            _db = db;
        }

        public Admins GetAdmin(string enteredAdmin)
        {
            var admin = _db.Admins.Where(a => a.AdminName == enteredAdmin).FirstOrDefault();
            EnteredAdmin = admin;
            return EnteredAdmin;
        }

        public void CreateAdmin(string enteredAdminName)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(string enteredAdmin)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdmin(Admins admin)
        {
            throw new NotImplementedException();
        }
    }
}
