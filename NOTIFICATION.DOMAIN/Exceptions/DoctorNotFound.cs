namespace NOTIFICATION.DOMAIN.Errors;

public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException(string message) : base(message)
    {
    }
}
