using HVACManagement.Data;
using HVACManagement.Models.Domain;
using HVACManagement.Repositories.Interfaces;

namespace HVACManagement.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Projects = new GenericRepository<Project>(_context);
        Employees = new GenericRepository<Employee>(_context);
        Attendances = new GenericRepository<Attendance>(_context);
        Notifications = new GenericRepository<Notification>(_context);
    }

    public IGenericRepository<Project> Projects { get; }
    public IGenericRepository<Employee> Employees { get; }
    public IGenericRepository<Attendance> Attendances { get; }
    public IGenericRepository<Notification> Notifications { get; }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
