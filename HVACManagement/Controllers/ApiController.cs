using HVACManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HVACManagement.Controllers;

[Authorize]
[Route("api")]
public class ApiController : Controller
{
    private readonly IProjectService _projectService;
    private readonly INotificationService _notificationService;

    public ApiController(IProjectService projectService, INotificationService notificationService)
    {
        _projectService = projectService;
        _notificationService = notificationService;
    }

    [HttpGet("projects/{id:int}/progress")]
    public async Task<IActionResult> GetProjectProgress(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        return Json(new { success = project is not null, data = project?.ProgressPercentage, message = project is null ? "Not found" : "OK" });
    }

    [HttpPost("tasks/{id:int}/progress")]
    public async Task<IActionResult> UpdateProjectProgress(int id, [FromForm] int progress)
    {
        await _projectService.UpdateProgressAsync(id, progress);
        return Json(new { success = true, data = progress, message = "Updated" });
    }

    [HttpGet("notifications/unread")]
    public async Task<IActionResult> GetUnread()
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type.EndsWith("nameidentifier"))?.Value;
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Json(new { success = false, data = Array.Empty<object>(), message = "User not found" });
        }

        var list = await _notificationService.GetUnreadAsync(userId);
        return Json(new { success = true, data = list, message = "OK" });
    }
}
