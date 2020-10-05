using IP_Booking_Overtime;
using IP_BusinessLayer;
using NUnit.Framework;
using System.Linq;

namespace BusinessLayerTesting
{
    public class Tests
    {
        CRUDoperations _crud = new CRUDoperations();
        Users user;

        [SetUp]
        public void Setup()
        {
            //using (var db = new IndividualProject_DatabaseContext())
            //{
            //    var user =
            //        from _user in db.Users
            //        where _user.UserId == 1
            //        select _user;
            //    db.Users.RemoveRange(user);
            //    db.SaveChanges();
            //}
        }

        [Test]
        public void WhenUsernameEnteredDoesNotExistInDataBase_ANullIsReturned()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var _input = _crud.GetUserForUserName("Nish");
                Assert.AreEqual(null, _input);
            }
        }

        [Test]
        public void WhenUserNameEnteredDoesExistsInTheDatabase_AUserObjectIsReturned()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var output = _crud.GetUserForUserName("Dawood");
                Assert.AreEqual("Dawood", output.UserName);
            }
        }

        [Test]
        public void WhenUserNameExists_EnteredUserShouldNotBeNullAndDoesNotCreateAndTheNumberOfUsersShouldNotChange()
        {
            using(var db = new IndividualProject_DatabaseContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                _crud.Create("Dawood");
                var numberOfUsersAfter = db.Users.Count();
                Assert.AreEqual("Dawood", _crud.EnteredUser.UserName);
                Assert.AreEqual(numberOfUsersAfter, numberOfUsersBefore);
            }
        }

        [Test]
        public void WhenUserNameDoesExist_EnteredUserShouldNotBeNullAndCreateDoesNotAddTheNewUserAndTheNumberOfUsersStaysTheSame()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                _crud.Create("Dawood");
                var numberOfUsersAfter = db.Users.Count();
                Assert.AreEqual(numberOfUsersAfter, numberOfUsersBefore);
            }
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnMonday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var useritems = _crud.PopulateOvertimeForMonday();
                Assert.AreEqual("Monday", useritems[0].Day);
            }
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnTuesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var useritems = _crud.PopulateOvertimeForTuesday();
                Assert.AreEqual("Tuesday", useritems[0].Day);
            }
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnWednesday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var useritems = _crud.PopulateOvertimeForWednesday();
                Assert.AreEqual("Wednesday", useritems[0].Day);
            }
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnThursday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var useritems = _crud.PopulateOvertimeForThursday();
                Assert.AreEqual("Thursday", useritems[0].Day);
            }
        }

        [Test]
        public void WhenPopulateOvertimeFor_Friday_ThenOnlyPopulateListForAvailableOvertimesOnFriday()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var useritems = _crud.PopulateOvertimeForFriday();
                Assert.AreEqual("Friday", useritems[0].Day);
            }
        }
    }
}