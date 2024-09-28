using NOTIFICATION.APPLICATION.Gateways;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Errors;

namespace NOTIFICATION.APPLICATION.UseCases.FindPatientById;

public class FindPatientById
{
    public Patient patient;

    private PatientGateway _patientGateway;

    public async Task<Patient> Execute(Guid patientId)
    {
        var patient = await _patientGateway.findPatientById(patientId);

        if (patient is null)
            throw new PatientNotFoundException($"Patient with ID {patientId} was not found.");

        return patient;
    }
}
