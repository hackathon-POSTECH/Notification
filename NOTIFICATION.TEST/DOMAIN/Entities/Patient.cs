using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.TEST.DOMAIN.Entities
{
    [TestFixture]
    public class PatientTests
    {
        [Test]
        public void Patient_Create_ShouldReturnValidPatientInstance()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var patientName = "John Doe";
            var patientEmail = "jane.smith@email.com";
            var patientPhoneNumber = "+123456789";

            // Act
            var patient = Patient.Create(patientId, patientName, patientEmail, patientPhoneNumber);

            // Assert
            Assert.That(patient, Is.Not.Null);
            Assert.That(patientId, Is.EqualTo(patient.Id));
            Assert.That(patientName, Is.EqualTo(patient.Name));
            Assert.That(patientEmail, Is.EqualTo(patient.Email));
            Assert.That(patientPhoneNumber, Is.EqualTo(patient.Phone));
        }

        [Test]
        public void Patient_Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var patientName = "Dr. John Doe";
            var patientEmail = "john.doe@hospital.com";
            var patientPhoneNumber = "+987654321";

            // Act
            var patient = new Patient(patientId, patientName, patientEmail, patientPhoneNumber);

            // Assert
            Assert.That(patientId, Is.EqualTo(patient.Id));
            Assert.That(patientName, Is.EqualTo(patient.Name));
            Assert.That(patientEmail, Is.EqualTo(patient.Email));
            Assert.That(patientPhoneNumber, Is.EqualTo(patient.Phone));
        }

        [Test]
        public void Patient_DefaultConstructor_ShouldCreateEmptyPatient()
        {
            // Act
            var patient = new Patient();

            // Assert
            Assert.That(patient, Is.Not.Null);
            Assert.That(Guid.Empty, Is.EqualTo(patient.Id));
            Assert.That(patient.Name, Is.Null);
            Assert.That(patient.Email, Is.Null);
            Assert.That(patient.Phone, Is.Null);
        }
    }
}
