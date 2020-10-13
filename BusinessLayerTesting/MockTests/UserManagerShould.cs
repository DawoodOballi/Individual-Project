using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using IP_BusinessLayer.MockBackEnd;
using IP_Booking_Overtime.ExampleDBModel;
using IP_BusinessLayer.ExampleDBModel;

namespace BusinessLayerTesting.MockTests
{
    [TestFixture]
    public class UserManagerShould
    {
        private UserManager _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<ExampleContext>()
                .UseInMemoryDatabase(databaseName: "Example_DB")
                .Options;
            var context = new ExampleContext(options);
            _sut = new UserManager(context);
            _sut.CreateUsers(new List<User>
            {
                new User() {UserId = 1, UserName = "Dawood"},
                new User() {UserId = 2, UserName = "Darren"},
                new User() {UserId = 3, UserName = "Daniel"},
                new User() {UserId = 4, UserName = "Suli"},
                new User() {UserId = 5, UserName = "Sami"},
                new User() {UserId = 6, UserName = "Vinni"},
                new User() {UserId = 7, UserName = "Yanga"},
            });
        }

        [Test]
        public void GivenAValidUserName_Return_UserId()
        {
            Assert.That(_sut.GetUserId("Dawood"), Is.EqualTo(1));
        }

        [Test]
        public void GivenANewUser_ItGetsAddedToTheDatabase()
        {
            var item = new User() { UserId = 8, UserName = "Bob" };
            Assert.That(_sut.FindUser("Bob"), Is.Null);
            _sut.AddUser(item);
            var theItem = _sut.FindUser("Bob");
            Assert.That(theItem.UserName, Is.EqualTo("Bob"));
            Assert.That(theItem.UserId, Is.EqualTo(8));
            _sut.RemoveUser("Bob");
        }
    }
}
