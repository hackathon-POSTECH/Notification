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
                        URIServiceDoctor + "verifyDoctor/" + doctorId,
                        HttpMethod.Get);

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
