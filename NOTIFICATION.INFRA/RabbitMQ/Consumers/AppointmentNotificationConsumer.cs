using MassTransit;
using Microsoft.Extensions.Configuration;
using Notification.DOMAIN.Messages;
using NOTIFICATION.INFRA.abstractions;
using System.Threading.Tasks;

namespace NOTIFICATION.INFRA.RabbitMQ.Consumers
{
    public class ApointmentNotificationDoctorConsumer : IConsumer<AppointmentNotificationDoctor>
    {
        private readonly IConfiguration _configuration;

        public ApointmentNotificationDoctorConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Consume(ConsumeContext<AppointmentNotificationDoctor> context)
        {
            var message = context.Message;

            await SendNotificationAsync(message);
        }

        private async Task SendNotificationAsync(AppointmentNotificationDoctor message)
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
                message.Doctor.Email,
                "Agendamento realizado com sucesso",
                message.Message);
        }
    }
}
