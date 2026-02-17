using HVACManagement.Models.Domain;

namespace HVACManagement.Repositories.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<Project> Projects { get; }
    IGenericRepository<Employee> Employees { get; }
    IGenericRepository<Attendance> Attendances { get; }
    IGenericRepository<Notification> Notifications { get; }
    Task<int> SaveChangesAsync();
}
