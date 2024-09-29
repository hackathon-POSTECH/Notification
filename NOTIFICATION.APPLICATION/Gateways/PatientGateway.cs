using Microsoft.Extensions.Configuration;
using NOTIFICATION.APPLICATION.Abstractions.Http;
using NOTIFICATION.APPLICATION.DTOs;
using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class PatientGateway : IPatientGateway
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public PatientGateway(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<Patient?> FindPatientById(Guid patientId)
        {
            try
            {
                var URIServicePatient = _configuration.GetSection("URIs")["Patient"];

                if (URIServicePatient is null)
                    throw new Exception("URI Service Patient not found in appsettings.json");

                var response =
                    await _httpClientService.RequestAsync<PatientResponseDTO>(
                        URIServicePatient + "getbyid/" + patientId,
                        HttpMethod.Head,
                        null,
                        new Dictionary<string, string>(
                            new List<KeyValuePair<string, string>>
                            {
                                new("Authorization",
                                    "Bearer " +
                                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.px9SiYNYDnbw3EG7AriQqk59KQcupoh02nDijQpJAMg")
                            })
                    );

                var patient = Patient.Create(
                    response.Id,
                    response.Name,
                    response.Email,
                    response.Phone
                );

                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
