using System.Net;
using System.Net.Mail;
using NOTIFICATION.DOMAIN.Entities;

namespace NOTIFICATION.INFRA.Adapters.Notification;

public class EmailNotification : INotification
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPassword;

    public EmailNotification(string smtpServer, int smtpPort, string smtpUser, string smtpPassword)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUser = smtpUser;
        _smtpPassword = smtpPassword;
    }

    public async Task SendNotificationAsync(string toEmail, string subject, string notificationText)
    {
        try
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUser, _smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(toEmail),
                Subject = subject,
                Body = notificationText,
                IsBodyHtml = false
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
