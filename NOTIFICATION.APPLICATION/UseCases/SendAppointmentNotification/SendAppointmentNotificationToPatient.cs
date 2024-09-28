using Microsoft.Extensions.Configuration;
using Notification.DOMAIN.Messages;
using NOTIFICATION.INFRA.abstractions;

namespace NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToPatient;

public class SendAppointmentNotificationToPatient
{
    private readonly IConfiguration _configuration;

    public SendAppointmentNotificationToPatient(
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }

    public async Task Execute(AppointmentNotification appointmentNotification)
    {
        var smtpSettings = _configuration.GetSection("SmtpSettings");

        var notification = NotificationFactory.CreateNotification(
            type: NotificationType.Email,
            smtpPort: int.Parse(smtpSettings["Port"]!),
            smtpServer: smtpSettings["Server"]!,
            smtpUser: smtpSettings["User"]!,
            smtpPassword: smtpSettings["Password"]!
        );

        var notificationSender = new NotificationSender(notification);

        await notificationSender.SendAsync(
            appointmentNotification.Patient.Email,
            "Agendamento realizado com sucesso",
            appointmentNotification.MessagePatient
        );
    }
}
