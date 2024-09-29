using NOTIFICATION.DOMAIN.Errors;

namespace NOTIFICATION.TEST.Domain.Exceptions
{
    [TestFixture]
    public class DoctorNotFoundTest
    {
        [Test]
        public void DoctorNotFoundException_ShouldCreateValidInstance()
        {
            // Arrange
            var message = "Doctor not found";

            // Act
            var exception = new DoctorNotFoundException(message);

            // Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(message, Is.EqualTo(exception.Message));
        }
    }
}
