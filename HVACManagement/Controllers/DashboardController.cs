using HVACManagement.Services.Interfaces;
using HVACManagement.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HVACManagement.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly IProjectService _projectService;

    public DashboardController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetAllAsync();
        var vm = new AdminDashboardViewModel
        {
            ActiveProjects = projects.Count,
            DelayedProjects = projects.Count(p => p.Status == Models.Enums.ProjectStatus.Delayed),
            ProjectsNearDeadline = projects.Count(p => p.DeadlineDate <= DateTime.UtcNow.Date.AddDays(7)),
            ActiveEmployees = 0
        };

        return View(vm);
    }
}
