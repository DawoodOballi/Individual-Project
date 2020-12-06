using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using IP_BusinessLayer;
using IP_Booking_Overtime;

namespace BusinessLayerTesting.MockTests
{
    [TestFixture]
    public class Overtime_UserCreatorTests
    {
        private OvertimeManager _sut;

        [Test]
        public void BeAbleToBeConstructed()
        {
            _sut = new OvertimeManager();
            Assert.That(_sut, Is.InstanceOf<OvertimeManager>());
        }

        [Test]
        public void BeAbleToBeConstructedUsingMoq()
        {
            var mockDatabase = new Mock<IndividualProject_DatabaseContext>();
            _sut = new OvertimeManager(mockDatabase.Object);
            Assert.That(_sut, Is.InstanceOf<OvertimeManager>());
        }

        [Test]
        public void 
    }
}
