using MassTransit;
using NOTIFICATION.APPLICATION.DTOs;
using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class DoctorGateway : IDoctorGateway
    {
        private readonly IRequestClient<DoctorRequestDTO> _requestClient;

        public DoctorGateway(IRequestClient<DoctorRequestDTO> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<Doctor?> FindDoctorById(Guid doctorId)
        {
            var response = await _requestClient.GetResponse<DoctorResponseDTO>(new DoctorRequestDTO
            {
                DoctorId = doctorId
            });

            var doctor = Doctor.Create(
                response.Message.Id,
                response.Message.Name,
                response.Message.Email,
                response.Message.Phone
            );

            return doctor;
        }
    }
}
