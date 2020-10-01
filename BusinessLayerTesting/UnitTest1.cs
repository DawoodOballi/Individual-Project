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

        [TestCase("Nish", null)]
        //[TestCase("Dawood", )]
        public void WhenUserNameEnteredDoesExistsInTheDatabase(string user, object exp)
        {
            using (var db = new IndividualProject_DatabaseContext())
            {
                var input = _crud.GetUserForUserName(user);
                Assert.AreEqual(exp, input);
            }
        }
    }
}