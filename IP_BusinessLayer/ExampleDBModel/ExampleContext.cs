using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_Booking_Overtime.ExampleDBModel
{
    public class ExampleContext : DbContext
    {
        public ExampleContext() { }

        public ExampleContext(DbContextOptions<ExampleContext> options): base(options)
        { }

        public virtual DbSet<Users> Users { get; set; }
    }
}
