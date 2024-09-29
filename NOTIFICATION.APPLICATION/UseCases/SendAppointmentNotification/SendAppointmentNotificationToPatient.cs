using Microsoft.Extensions.Configuration;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Factories;
using Notification.DOMAIN.Messages;

namespace NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToPatient;

public class SendAppointmentNotificationToPatient
{
    private readonly IConfiguration _configuration;
    private readonly INotificationFactory _notificationFactory;
    private readonly FindPatientById _findPatientById;
    private readonly FindDoctorById _findDoctorById;

    public SendAppointmentNotificationToPatient(
        IConfiguration configuration,
        INotificationFactory notificationFactory,
        FindPatientById findPatient,
        FindDoctorById findDoctor
    )
    {
        _configuration = configuration;
        _notificationFactory = notificationFactory;
        _findPatientById = findPatient;
        _findDoctorById = findDoctor;
    }

    public async Task Execute(AppointmentNotificationEvent appointmentNotificationEvent)
    {
        try
        {
            var doctor = await _findDoctorById.Execute(appointmentNotificationEvent.Doctor);
            var patient = await _findPatientById.Execute(appointmentNotificationEvent.Patient);
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            var notification = _notificationFactory.CreateNotification(
                type: NotificationType.Email,
                smtpPort: int.Parse(smtpSettings["Port"]!),
                smtpServer: smtpSettings["Server"]!,
                smtpUser: smtpSettings["User"]!,
                smtpPassword: smtpSettings["Password"]!
            );


            var notificationSender = _notificationFactory.CreateNotificationStrategy(notification);

            await notificationSender.SendAsync(
                patient.Email,
                "Agendamento realizado com sucesso",
                BuildMessagePatient(
                    doctor,
                    patient,
                    appointmentNotificationEvent.AppointmentDate,
                    appointmentNotificationEvent.AppointmentTime
                )
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string BuildMessagePatient(
        Doctor doctor,
        Patient patient,
        DateTime appointmentDate,
        TimeSpan appointmentTime
    )
    {
        return $"Olá, {patient.Name}!\n" +
               $"Sua consulta foi marcada com sucesso!\n" +
               $"Médico: Dr. {doctor.Name}.\n" +
               $"Data e horário: {appointmentDate.ToShortDateString()} às {appointmentTime}.";
    }
}
