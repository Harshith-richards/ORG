using HVACManagement.Models.Domain;
using HVACManagement.Repositories.Interfaces;
using HVACManagement.Services.Interfaces;

namespace HVACManagement.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _uow;

    public ProjectService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public Task<IReadOnlyList<Project>> GetAllAsync() => _uow.Projects.ListAsync();

    public Task<Project?> GetByIdAsync(int id) => _uow.Projects.GetByIdAsync(id);

    public async Task CreateAsync(Project project)
    {
        await _uow.Projects.AddAsync(project);
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateProgressAsync(int id, int progress)
    {
        var project = await _uow.Projects.GetByIdAsync(id) ?? throw new InvalidOperationException("Project not found.");
        project.ProgressPercentage = Math.Clamp(progress, 0, 100);
        _uow.Projects.Update(project);
        await _uow.SaveChangesAsync();
    }
}
