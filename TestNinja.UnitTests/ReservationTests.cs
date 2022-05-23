using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminUserCancelling_ReturnsTrue()
        {
            // Arrange
            var user = new User { IsAdmin = true };
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);          // Exactly the same for NUnit & MSTest
            Assert.That(result, Is.True);   // Only for NUnit
            Assert.That(result == true);    // Only for NUnit
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            // Arrange
            var user = new User { IsAdmin = true };
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
