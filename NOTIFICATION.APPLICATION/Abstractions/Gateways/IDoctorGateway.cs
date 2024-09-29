using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public interface IDoctorGateway
    {
        Task<Doctor?> FindDoctorById(Guid doctorId);
    }
}
