using MassTransit;
using NOTIFICATION.APPLICATION.DTOs;
using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class PatientGateway : IPatientGateway
    {
        private readonly IRequestClient<PatientRequestDTO> _requestClient;

        public PatientGateway(IRequestClient<PatientRequestDTO> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task<Patient?> FindPatientById(Guid patientId)
        {
            var response = await _requestClient.GetResponse<PatientResponseDTO>(new PatientRequestDTO
            {
                PatientId = patientId
            });

            var patient = Patient.Create(
                response.Message.Id,
                response.Message.Name,
                response.Message.Email,
                response.Message.Phone
            );

            return patient;
        }
    }
}
