using NOTIFICATION.APPLICATION.Gateways;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Errors;

namespace NOTIFICATION.APPLICATION.UseCases;

public class FindPatientById
{
    private IPatientGateway _patientGatewayInterface;

    public FindPatientById(IPatientGateway patientGatewayInterface)
    {
        _patientGatewayInterface = patientGatewayInterface;
    }

    public async Task<Patient> Execute(Guid patientId)
    {
        var patient = await _patientGatewayInterface.FindPatientById(patientId);

        if (patient is null)
            throw new PatientNotFoundException($"Patient with ID {patientId} was not found.");

        return patient;
    }
}
