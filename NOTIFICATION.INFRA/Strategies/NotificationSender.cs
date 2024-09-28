using NOTIFICATION.INFRA.abstractions;

namespace NOTIFICATION.INFRA.strategies;

public class NotificationSender
{
    private readonly INotification _notificationStrategy;

    public NotificationSender(INotification notificationStrategy)
    {
        _notificationStrategy = notificationStrategy;
    }

    public async Task SendAsync(string recipient, string subject, string message)
    {
        await _notificationStrategy.SendNotificationAsync(recipient, subject, message);
    }
}
