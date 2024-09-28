using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways;

abstract class PatientGateway
{
    public abstract Task<Patient?> findPatientById(Guid patientId);
}
