using NOTIFICATION.APPLICATION.Gateways;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Errors;

namespace NOTIFICATION.APPLICATION.UseCases;

public class FindDoctorById
{
    private IDoctorGateway _doctorGateway;

    public FindDoctorById(IDoctorGateway doctorGateway)
    {
        _doctorGateway = doctorGateway;
    }

    public async Task<Doctor> Execute(Guid doctorId)
    {
        var doctor = await _doctorGateway.FindDoctorById(doctorId);

        if (doctor is null)
            throw new DoctorNotFoundException($"Doctor with ID {doctorId} was not found.");

        return doctor;
    }
}
