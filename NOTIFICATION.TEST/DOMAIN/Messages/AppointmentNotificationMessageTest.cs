using Notification.DOMAIN.Messages;

namespace Notification.TEST.DOMAIN.Messages
{
    [TestFixture]
    public class AppointmentNotificationMessageTests
    {
        [Test]
        public void AppointmentNotificationMessage_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var appointmentDate = new DateTime(2024, 10, 1);
            var appointmentTime = new TimeSpan(14, 30, 0); // 14:30:00

            // Act
            var notificationMessage = new AppointmentNotificationMessage(
                doctorId,
                patientId,
                appointmentDate,
                appointmentTime
            );

            // Assert
            Assert.That(notificationMessage.Doctor, Is.EqualTo(doctorId));
            Assert.That(notificationMessage.Patient, Is.EqualTo(patientId));
            Assert.That(notificationMessage.AppointmentDate, Is.EqualTo(appointmentDate));
            Assert.That(notificationMessage.AppointmentTime, Is.EqualTo(appointmentTime));
        }
    }
}
