using NOTIFICATION.INFRA.abstractions;
using NOTIFICATION.INFRA.Adapters.Notification;

namespace NOTIFICATION.INFRA.Factories;

public enum NotificationType
{
    Email,
    Sms
}

public class NotificationFactory
{
    private Notification

    public static INotification CreateNotification(NotificationType type, string smtpServer = null, int smtpPort = 0,
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
}
