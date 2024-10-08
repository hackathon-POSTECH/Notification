using MassTransit;
using NOTIFICATION.APPLICATION;
using Notification.DOMAIN.Messages;

public class NotificationService : INotificationService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task SendNotificationAsync()
    {
        var message = new AppointmentNotificationMessage(
            doctor: Guid.NewGuid(),
            patient: Guid.NewGuid(),
            appointmentDate: DateTime.Now,
            appointmentTime: new TimeSpan(10, 0, 0)
        );

        await _publishEndpoint.Publish(message);
    }
}
