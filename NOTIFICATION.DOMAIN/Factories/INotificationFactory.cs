using NOTIFICATION.DOMAIN.Entities;
using NOTIFICATION.DOMAIN.Strategies;

namespace NOTIFICATION.DOMAIN.Factories
{
    public interface INotificationFactory
    {
        INotification CreateNotification(NotificationType type, string smtpServer, int smtpPort, string smtpUser,
            string smtpPassword);
        INotificationStrategy CreateNotificationStrategy(INotification notification);
    }
}
