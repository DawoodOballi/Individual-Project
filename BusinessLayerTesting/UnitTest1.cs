using IP_Booking_Overtime;
using IP_BusinessLayer;
using NUnit.Framework;

namespace BusinessLayerTesting
{
    public class Tests
    {
        CRUDoperations _crud = new CRUDoperations();
        Users user;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenUsernameEnteredDoesNotExistInDataBase_AnErrorMessageIsDisplayed()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var _input = _crud.GetUserForUserName("Nish");
                Assert.AreEqual(null, _input);
            }
        }

        [Test]
        public void WhenUserNameEnteredDoesExistsInTheDatabase()
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var output = _crud.GetUserForUserName("Dawood");
                Assert.AreEqual("Dawood", output.UserName);
            }
        }
    }
}