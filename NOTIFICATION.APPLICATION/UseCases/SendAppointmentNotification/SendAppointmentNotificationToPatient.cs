using Microsoft.Extensions.Configuration;
using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Factories;
using Notification.DOMAIN.Messages;

namespace NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToPatient;

public class SendAppointmentNotificationToPatient
{
    private readonly IConfiguration _configuration;
    private readonly INotificationFactory _notificationFactory;

    public SendAppointmentNotificationToPatient(
        IConfiguration configuration,
        INotificationFactory notificationFactory
    )
    {
        _configuration = configuration;
        _notificationFactory = notificationFactory;
    }

    public async Task Execute(AppointmentNotification appointmentNotification)
    {
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
            appointmentNotification.Patient.Email,
            "Agendamento realizado com sucesso",
            appointmentNotification.MessagePatient
        );
    }
}
