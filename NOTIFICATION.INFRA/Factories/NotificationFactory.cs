using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Factories;
using NOTIFICATION.DOMAIN.Strategies;
using NOTIFICATION.INFRA.Adapters.Notification;
using NOTIFICATION.INFRA.strategies;

namespace NOTIFICATION.INFRA.Factories;

public class NotificationFactory : INotificationFactory
{
    public INotification CreateNotification(NotificationType type, string smtpServer = null,
        int smtpPort = 0,
        string smtpUser = null, string smtpPassword = null)
    {
        switch (type)
        {
            case NotificationType.Email:
                if (smtpServer == null || smtpUser == null || smtpPassword == null)
                {
                    throw new ArgumentException("Missing email configuration");
                }

                return new EmailNotification(smtpServer, smtpPort, smtpUser, smtpPassword);

            case NotificationType.Sms:
                return new SmsNotification();

            default:
                throw new NotSupportedException($"Notification type {type} is not supported");
        }
    }

    public INotificationStrategy CreateNotificationStrategy(INotification notification)
    {
        return new NotificationSender(notification);
    }
}
