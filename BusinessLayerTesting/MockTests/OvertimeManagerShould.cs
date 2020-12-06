//using IP_Booking_Overtime;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.EntityFrameworkCore;
//using IP_BusinessLayer;

//namespace BusinessLayerTesting.MockTests
//{

//    [TestFixture]
//    public class OvertimeManagerShould
//    {
//        OvertimeManager overtimeManager;

//        [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            var options = new DbContextOptionsBuilder<IndividualProject_DatabaseContext>()
//                .UseInMemoryDatabase(databaseName: "IP_DB")
//                .Options;
//            var context = new IndividualProject_DatabaseContext(options);
//            overtimeManager = new OvertimeManager(context);
//            overtimeManager.CreateOvertimeList(new List<Overtime>
//            {
//                new Overtime() {Day = "Monday", StartTime = new TimeSpan(3, 0, 0), NumberOfHours = 3},
//                new Overtime() {Day = "Tuesday", StartTime = new TimeSpan(16, 0, 0), NumberOfHours = 10},
//                new Overtime() { Day = "Tuesday", StartTime = new TimeSpan(13, 0, 0), NumberOfHours = 4},
//                new Overtime() {Day = "Wednesday", StartTime = new TimeSpan(2, 0, 0), NumberOfHours = 6},
//                new Overtime() {Day = "Thursday", StartTime = new TimeSpan(11, 0, 0), NumberOfHours = 8},
//                new Overtime() {Day = "Thursday", StartTime = new TimeSpan(0, 0, 0), NumberOfHours = 7},
//                new Overtime() {Day = "Friday", StartTime = new TimeSpan(23, 0, 0), NumberOfHours = 5},
//                new Overtime() {Day = "Friday", StartTime = new TimeSpan(14, 0, 0), NumberOfHours = 4},
//                new Overtime() {Day = "Friday", StartTime = new TimeSpan(17, 0, 0), NumberOfHours = 6},
//            });
//        }

//        [Test]
//        public void GivenAValidOvertime_Returns_AOvertimeObject()
//        {
//            Assert.That(overtimeManager.GetOvertime(2), Is.InstanceOf<Overtime>());
//        }

//        [Test]
//        public void GivenANewOvertime_ItGetsAddedToTheDatabase()
//        {
//            object item = new Overtime() { Day = "Monday", StartTime = TimeSpan.Parse("18:00"), NumberOfHours = 5 };
//            overtimeManager.GetSelectedOvertime(item);
//            Overtime newItem = (Overtime)item;
//            overtimeManager.CreateOvertime(newItem.Day, newItem.StartTime.Value, newItem.NumberOfHours.ToString());
//            overtimeManager.GetSelectedOvertime(newItem);
//            Assert.That(newItem.StartTime, Is.EqualTo(new TimeSpan(18, 0, 0)));
//            Assert.That(newItem.Day, Is.EqualTo("Monday"));
//            overtimeManager.RemoveOvertime(newItem);
//        }
//    }
//}
