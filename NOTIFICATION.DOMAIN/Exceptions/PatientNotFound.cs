namespace NOTIFICATION.DOMAIN.Errors;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string message) : base(message)
    {
    }
}
