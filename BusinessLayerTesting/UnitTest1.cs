using IP_Booking_Overtime;
using IP_BusinessLayer;
using NUnit.Framework;
using System.Linq;

namespace BusinessLayerTesting
{
    public class Tests
    {
        UserManager userManager = new UserManager();
        OvertimeManager overtimeManager = new OvertimeManager();
        AdminManager adminManager = new AdminManager();
        IndividualProject_DatabaseContext db = new IndividualProject_DatabaseContext();


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenUsernameEnteredDoesNotExistInDataBase_ANullIsReturned()
        {
            var _input = userManager.GetUserForUserName("Nish");
            Assert.AreEqual(null, _input);
        }

        [Test]
        public void WhenUserNameEnteredDoesExistsInTheDatabase_AUserObjectIsReturned()
        {
            var output = userManager.GetUserForUserName("Dawood");
            Assert.AreEqual("Dawood", output.UserName);
        }

        [Test]
        public void WhenUserNameExists_EnteredUserShouldNotBeNullAndDoesNotCreateAndTheNumberOfUsersShouldNotChange()
        {
            var numberOfUsersBefore = db.Users.Count();
            userManager.CreateUser("Dawood");
            var numberOfUsersAfter = db.Users.Count();
            Assert.AreEqual("Dawood", userManager.EnteredUser.UserName);
            Assert.AreEqual(numberOfUsersAfter, numberOfUsersBefore);
            
        }

        [Test]
        public void WhenUserNameDoesExist_EnteredUserShouldNotBeNullAndCreateDoesNotAddTheNewUserAndTheNumberOfUsersStaysTheSame()
        {
            var numberOfUsersBefore = db.Users.Count();
            userManager.CreateUser("Dawood");
            var numberOfUsersAfter = db.Users.Count();
            Assert.AreEqual(numberOfUsersAfter, numberOfUsersBefore);
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnMonday()
        {
            var useritems = overtimeManager.PopulateOvertimeForMonday();
            Assert.AreEqual("Monday", useritems[0].Day);
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnTuesday()
        {
            var useritems = overtimeManager.PopulateOvertimeForTuesday();
            Assert.AreEqual("Tuesday", useritems[0].Day);
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnWednesday()
        {
            var useritems = overtimeManager.PopulateOvertimeForWednesday();
            Assert.AreEqual("Wednesday", useritems[0].Day);
        }

        [Test]
        public void WhenPopulateOvertimeFor_Monday_ThenOnlyPopulateListForAvailableOvertimesOnThursday()
        {
            var useritems = overtimeManager.PopulateOvertimeForThursday();
            Assert.AreEqual("Thursday", useritems[0].Day);
        }

        [Test]
        public void WhenPopulateOvertimeFor_Friday_ThenOnlyPopulateListForAvailableOvertimesOnFriday()
        {
            var useritems = overtimeManager.PopulateOvertimeForFriday();
            Assert.AreEqual("Friday", useritems[0].Day);
        }

        [Test]
        public void WhenSelectedItemIsBookedAndCancelIsClicked_ThenRemnoveTheUserIdConnectionToTheSelectedSlot()
        {
            var user = userManager.GetUserForUserName("Dawood");
            object overtime = db.Overtime.Where(o => o.OvertimeId == user.UserId).FirstOrDefault();
            overtimeManager.SetUser_IDs_ForBookedOvertime(user, overtime);
            overtimeManager.RemoveUser_IDs_FromBookedOvertime(overtime);
            Assert.AreEqual(null, overtimeManager.SelectedOvertime.UserId);
        }

        [Test]
        public void WhenSelectedItemIsNotBookedAndBookIsClicked_ThenAddTheUserIdConnectionToTheSelectedSlot()
        {
            var user = userManager.GetUserForUserName("Dawood");
            object overtime = db.Overtime.Where(o => o.OvertimeId == 1).FirstOrDefault();
            overtimeManager.SetUser_IDs_ForBookedOvertime(user, overtime);
            Assert.AreEqual(overtimeManager.SelectedOvertime.UserId, user.UserId);
        }

        [Test]
        public void WhenEnteredAdminIsInDatabase_AnAdminObjectIsReturnedWithTheirName()
        {
            var admin = adminManager.GetAdmin("Cathy");
            Assert.AreEqual("Cathy", admin.AdminName);

        }

        [Test]
        public void WhenEnteredAdminIsNotInDatabase_NullIsReturned()
        {
            var admin = adminManager.GetAdmin("Dawood");
            Assert.AreEqual(null, admin);

        }

        [Test]
        public void WhenSelectedOvertimeOverlaps_FalseIsReturned()
        {
            var user = userManager.GetUserForUserName("Dawood");
            object overtime = db.Overtime.Where(o => o.OvertimeId == 3).FirstOrDefault();
            bool overlaps = overtimeManager.CheckForOverlap(user, overtime);
            Assert.AreEqual(false, overlaps);

        }

        [Test]
        public void WhenSelectedOvertimeDoesNotOverlap_TrueIsReturned()
        {

            var user = userManager.GetUserForUserName("Dawood");
            object overtime = db.Overtime.Where(o => o.OvertimeId == 7).FirstOrDefault();
            bool overlaps = overtimeManager.CheckForOverlap(user, overtime);
            Assert.AreEqual(true, overlaps);

        }
    }
}