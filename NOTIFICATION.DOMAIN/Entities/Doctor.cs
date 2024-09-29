namespace NOTIFICATION.DOMAIN.Entities;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Doctor()
    {
    }

    public Doctor(Guid doctorId, string doctorName, string doctorEmail, string doctorPhoneNumber)
    {
        Id = doctorId;
        Name = doctorName;
        Email = doctorEmail;
        Phone = doctorPhoneNumber;
    }

    public static Doctor Create(Guid doctorId, string doctorName, string doctorEmail, string doctorPhoneNumber)
    {
        return new Doctor(doctorId, doctorName, doctorEmail, doctorPhoneNumber);
    }
}
