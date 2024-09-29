using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public interface IPatientGateway
    {
        Task<Patient?> FindPatientById(Guid patientId);
    }
}
