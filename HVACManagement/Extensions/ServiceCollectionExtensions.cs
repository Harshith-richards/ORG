using HVACManagement.Repositories.Implementations;
using HVACManagement.Repositories.Interfaces;
using HVACManagement.Services.Implementations;
using HVACManagement.Services.Interfaces;

namespace HVACManagement.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}
