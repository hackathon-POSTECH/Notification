namespace NOTIFICATION.DOMAIN.Entities;

public class Patient
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }

    public Patient()
    {
    }

    public Patient(Guid patientId, string patientName, string patientEmail, string patientPhoneNumber)
    {
        Id = patientId;
        Name = patientName;
        Email = patientEmail;
        Phone = patientPhoneNumber;
    }

    public static Patient Create(Guid patientId, string patientName, string patientEmail, string patientPhoneNumber)
    {
        return new Patient(patientId, patientName, patientEmail, patientPhoneNumber);
    }
}
