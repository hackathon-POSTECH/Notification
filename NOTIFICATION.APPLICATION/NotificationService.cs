using MassTransit;
using NOTIFICATION.APPLICATION;
using NOTIFICATION.DOMAIN.Entities;
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
        var message = new AppointmentNotification(
            doctor: new Doctor(
                doctorName: "Jônatas Alves",
                doctorId: Guid.NewGuid(),
                doctorEmail: "alvesjonatas99@gmail.com",
                doctorPhoneNumber: ""
            ),
            patient: new Patient(
                patientName: "Jônatas Alves",
                patientId: Guid.NewGuid(),
                patientEmail: "alvesjonatas99@gmail.com",
                patientPhoneNumber: ""
            ),
            appointmentDate: DateTime.Now,
            appointmentTime: new TimeSpan(10, 0, 0)
        );

        await _publishEndpoint.Publish(message);
    }
}
