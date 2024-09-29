using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class DoctorGateway : IDoctorGateway
    {
        public Task<Doctor?> FindDoctorById(Guid doctorId)
        {
            var doctor = new Doctor(
                doctorId,
                "Dr. John Doe",
                "alvesjonatas99@gmail.com",
                "(123) 456-7890"
            );

            return Task.FromResult<Doctor?>(doctor);
        }
    }
}
