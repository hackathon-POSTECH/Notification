using Microsoft.AspNetCore.Mvc;
using NOTIFICATION.APPLICATION;

namespace NOTIFICATION.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] string notificationText)
    {
        await _notificationService.SendNotificationAsync();

        return Ok("Notification sent.");
    }
}
