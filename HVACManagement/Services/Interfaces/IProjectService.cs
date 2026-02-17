using HVACManagement.Models.Domain;

namespace HVACManagement.Services.Interfaces;

public interface IProjectService
{
    Task<IReadOnlyList<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task CreateAsync(Project project);
    Task UpdateProgressAsync(int id, int progress);
}
