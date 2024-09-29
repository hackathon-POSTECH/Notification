using Microsoft.Extensions.Configuration;
using NOTIFICATION.APPLICATION.Abstractions.Http;
using NOTIFICATION.APPLICATION.DTOs;
using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.APPLICATION.Gateways
{
    public class DoctorGateway : IDoctorGateway
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public DoctorGateway(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<Doctor?> FindDoctorById(Guid doctorId)
        {
            try
            {
                var URIServiceDoctor = _configuration.GetSection("URIs")["Doctor"];

                if (URIServiceDoctor is null)
                    throw new Exception("URI Service Doctor not found in appsettings.json");

                var response =
                    await _httpClientService.RequestAsync<DoctorResponseDTO>(
                        URIServiceDoctor + "getbyid/" + doctorId,
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

                var doctor = Doctor.Create(
                    response.Id,
                    response.Name,
                    response.Email,
                    response.Phone
                );

                return doctor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
