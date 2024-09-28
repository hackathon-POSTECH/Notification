using System.Net;
using System.Net.Mail;

namespace NOTIFICATION.INFRA.abstractions;

public interface INotification
{
    Task SendNotificationAsync(string recipient, string subject, string message);
}




