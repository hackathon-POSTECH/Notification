using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class PatientGateway : IPatientGateway
    {
        public Task<Patient?> FindPatientById(Guid doctorId)
        {
            var doctor = new Patient(
                doctorId,
                "Jonatas Alves",
                "alvesjonatas99@gmail.com",
                "(123) 456-7890"
            );

            return Task.FromResult<Patient?>(doctor);
        }
    }
}
