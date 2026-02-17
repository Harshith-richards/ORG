using HVACManagement.Models.Domain;
using HVACManagement.Services.Interfaces;
using HVACManagement.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HVACManagement.Controllers;

[Authorize]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetAllAsync();
        return View(projects);
    }

    [Authorize(Roles = "Admin,SuperAdmin,Manager")]
    public IActionResult Create() => View(new ProjectCreateViewModel());

    [HttpPost]
    [Authorize(Roles = "Admin,SuperAdmin,Manager")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectCreateViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        await _projectService.CreateAsync(new Project
        {
            ProjectName = vm.ProjectName,
            ProjectCode = vm.ProjectCode,
            ClientId = vm.ClientId,
            StartDate = vm.StartDate,
            DeadlineDate = vm.DeadlineDate,
            Budget = vm.Budget,
            Description = vm.Description,
            Status = vm.Status,
            ProgressPercentage = 0
        });

        return RedirectToAction(nameof(Index));
    }
}
