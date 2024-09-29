using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.TESTS.Domain.Entities
{
    [TestFixture]
    public class DoctorTests
    {
        [Test]
        public void Doctor_Create_ShouldReturnValidDoctorInstance()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var doctorName = "Dr. Jane Smith";
            var doctorEmail = "jane.smith@hospital.com";
            var doctorPhoneNumber = "+123456789";

            // Act
            var doctor = Doctor.Create(doctorId, doctorName, doctorEmail, doctorPhoneNumber);

            // Assert
            Assert.That(doctor, Is.Not.Null);
            Assert.That(doctorId, Is.EqualTo(doctor.Id));
            Assert.That(doctorName, Is.EqualTo(doctor.Name));
            Assert.That(doctorEmail, Is.EqualTo(doctor.Email));
            Assert.That(doctorPhoneNumber, Is.EqualTo(doctor.Phone));
        }

        [Test]
        public void Doctor_Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var doctorName = "Dr. John Doe";
            var doctorEmail = "john.doe@hospital.com";
            var doctorPhoneNumber = "+987654321";

            // Act
            var doctor = new Doctor(doctorId, doctorName, doctorEmail, doctorPhoneNumber);

            // Assert
            Assert.That(doctorId, Is.EqualTo(doctor.Id));
            Assert.That(doctorName, Is.EqualTo(doctor.Name));
            Assert.That(doctorEmail, Is.EqualTo(doctor.Email));
            Assert.That(doctorPhoneNumber, Is.EqualTo(doctor.Phone));
        }

        [Test]
        public void Doctor_DefaultConstructor_ShouldCreateEmptyDoctor()
        {
            // Act
            var doctor = new Doctor();

            // Assert
            Assert.That(doctor, Is.Not.Null);
            Assert.That(Guid.Empty, Is.EqualTo(doctor.Id));
            Assert.That(doctor.Name, Is.Null);
            Assert.That(doctor.Email, Is.Null);
            Assert.That(doctor.Phone, Is.Null);
        }
    }
}
