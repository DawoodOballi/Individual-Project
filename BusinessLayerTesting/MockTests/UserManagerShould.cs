using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using IP_BusinessLayer;
using IP_Booking_Overtime;
using Moq.Language;

namespace BusinessLayerTesting.MockTests
{
    [TestFixture]
    public class UserManagerShould
    {
        //Note: dont need an example context. Can use the actual context because were using InMemory.
        private UserManager _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<IndividualProject_DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "IP_DB")
                .Options;
            var context = new IndividualProject_DatabaseContext(options);
            _sut = new UserManager(context);
            _sut.CreateUsers(new List<Users>
            {
                new Users() {UserId = 1, UserName = "Dawood"},
                new Users() {UserId = 2, UserName = "Darren"},
                new Users() {UserId = 3, UserName = "Daniel"},
                new Users() {UserId = 4, UserName = "Suli"},
                new Users() {UserId = 5, UserName = "Sami"},
                new Users() {UserId = 6, UserName = "Vinni"},
                new Users() {UserId = 7, UserName = "Yanga"},
            });
        }

        [Test]
        public void GivenAValidUserName_Returns_AUsersObject()
        {
            Assert.That(_sut.GetUserForUserName("Dawood"), Is.InstanceOf<Users>());
        }

        [Test]
        public void GivenANewUser_ItGetsAddedToTheDatabase()
        {
            var item = new Users() { UserId = 8, UserName = "Bob" };
            Assert.That(_sut.GetUserForUserName("Bob"), Is.Null);
            _sut.AddUser(item);
            var theItem = _sut.GetUserForUserName("Bob");
            Assert.That(theItem.UserName, Is.EqualTo("Bob"));
            Assert.That(theItem.UserId, Is.EqualTo(8));
            _sut.RemoveUser("Bob");
        }
    }
}
