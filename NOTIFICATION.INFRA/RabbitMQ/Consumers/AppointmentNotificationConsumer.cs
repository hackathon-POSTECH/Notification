using MassTransit;
using Microsoft.Extensions.Configuration;
using NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToDoctor;
using NOTIFICATION.APPLICATION.UseCases.SendAppointmentNotificationToPatient;
using Notification.DOMAIN.Messages;

namespace NOTIFICATION.INFRA.RabbitMQ.Consumers
{
    public class AppointmentNotificationConsumer : IConsumer<AppointmentNotification>
    {
        private readonly IConfiguration _configuration;
        private readonly SendAppointmentNotificationToPatient _sendAppointmentNotificationToPatient;
        private readonly SendAppointmentNotificationToDoctor _sendAppointmentNotificationToDoctor;

        public AppointmentNotificationConsumer(IConfiguration configuration,
            SendAppointmentNotificationToPatient sendAppointmentNotificationToPatient,
            SendAppointmentNotificationToDoctor sendAppointmentNotificationToDoctor)
        {
            _configuration = configuration;
            _sendAppointmentNotificationToPatient = sendAppointmentNotificationToPatient;
            _sendAppointmentNotificationToDoctor = sendAppointmentNotificationToDoctor;
        }


        public async Task Consume(ConsumeContext<AppointmentNotification> context)
        {
            var message = context.Message;

            await _sendAppointmentNotificationToDoctor.Execute(message);
            await _sendAppointmentNotificationToPatient.Execute(message);
        }
    }
}
