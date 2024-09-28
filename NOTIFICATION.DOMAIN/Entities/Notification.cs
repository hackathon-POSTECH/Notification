using System.Net;
using System.Net.Mail;

namespace NOTIFICATION.DOMAIN.Entities;

public enum NotificationType
{
    Email,
    Sms
}

public interface INotification
{
    Task SendNotificationAsync(string recipient, string subject, string message);
}
