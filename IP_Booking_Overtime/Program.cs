using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Threading;

namespace IP_Booking_Overtime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TimeSpan aStart = TimeSpan.Parse("13:00");
            TimeSpan aEnd = TimeSpan.Parse("18:00");
            TimeSpan bStart = TimeSpan.Parse("10:00");
            TimeSpan bEnd = TimeSpan.Parse("19:00");

            TimeSpan end = aStart.Add(TimeSpan.Parse("12:00"));
        }
    }
}
