namespace NOTIFICATION.DOMAIN.Strategies
{
    public interface INotificationStrategy
    {
        Task SendAsync(string recipient, string subject, string message);
    }
}
