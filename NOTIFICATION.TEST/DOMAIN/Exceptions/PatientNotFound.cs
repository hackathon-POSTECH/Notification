using NOTIFICATION.DOMAIN.Errors;

namespace NOTIFICATION.TEST.Domain.Exceptions
{
    [TestFixture]
    public class PatientNotFoundTest
    {
        [Test]
        public void PatientNotFoundException_ShouldCreateValidInstance()
        {
            // Arrange
            var message = "Patient not found";

            // Act
            var exception = new PatientNotFoundException(message);

            // Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(message, Is.EqualTo(exception.Message));
        }
    }
}
