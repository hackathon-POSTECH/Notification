using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.INFRA.Adapters.Notification;

public class SmsNotification : INotification
{
    public async Task SendNotificationAsync(string recipientPhoneNumber, string subject, string message)
    {
        Console.WriteLine($"Sending SMS to {recipientPhoneNumber}: {message}");
        await Task.Delay(500); // Simula envio de SMS
        Console.WriteLine("SMS sent successfully.");
    }
}
