using Microsoft.Extensions.Configuration;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Factories;
using Notification.DOMAIN.Messages;

namespace NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToDoctor;

public class SendAppointmentNotificationToDoctor
{
    private readonly IConfiguration _configuration;
    private readonly INotificationFactory _notificationFactory;
    private readonly FindPatientById _findPatientById;
    private readonly FindDoctorById _findDoctorById;

    public SendAppointmentNotificationToDoctor(
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

    public async Task Execute(AppointmentNotificationMessage appointmentNotificationMessage)
    {
        try
        {
            var doctor = await _findDoctorById.Execute(appointmentNotificationMessage.Doctor);
            var patient = await _findPatientById.Execute(appointmentNotificationMessage.Patient);

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
                doctor.Email,
                "Agendamento realizado com sucesso",
                BuildMessageDoctor(
                    doctor,
                    patient,
                    appointmentNotificationMessage.AppointmentDate,
                    appointmentNotificationMessage.AppointmentTime
                )
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string BuildMessageDoctor(
        Doctor doctor,
        Patient patient,
        DateTime appointmentDate,
        TimeSpan appointmentTime
    )
    {
        return $"Olá, Dr. {doctor.Name}!\n" +
               $"Você tem uma nova consulta marcada!\n" +
               $"Paciente: {patient.Name}.\n" +
               $"Data e horário: {appointmentDate.ToShortDateString()} às {appointmentTime}.";
    }
}
