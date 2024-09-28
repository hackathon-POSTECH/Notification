using Microsoft.AspNetCore.Mvc;
using NOTIFICATION.APPLICATION;

namespace NOTIFICATION.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentNotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public AppointmentNotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] string notificationText)
    {
        try
        {
            await _notificationService.SendNotificationAsync();

            return Ok("Notification sent.");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
