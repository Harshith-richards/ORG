using HVACManagement.Models.Domain;
using HVACManagement.Models.Enums;
using HVACManagement.Repositories.Interfaces;
using HVACManagement.Services.Interfaces;

namespace HVACManagement.Services.Implementations;

public class AttendanceService : IAttendanceService
{
    private readonly IUnitOfWork _uow;

    public AttendanceService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Attendance?> GetTodayAsync(int employeeId)
    {
        return (await _uow.Attendances.ListAsync(a => a.EmployeeId == employeeId && a.Date == DateOnly.FromDateTime(DateTime.UtcNow.Date))).FirstOrDefault();
    }

    public async Task CheckInAsync(int employeeId)
    {
        var today = await GetTodayAsync(employeeId);
        if (today is not null && today.CheckInTime.HasValue)
        {
            throw new InvalidOperationException("Already checked in today.");
        }

        if (today is null)
        {
            today = new Attendance { EmployeeId = employeeId, Date = DateOnly.FromDateTime(DateTime.UtcNow.Date) };
            await _uow.Attendances.AddAsync(today);
        }

        today.CheckInTime = DateTime.UtcNow;
        today.Status = today.CheckInTime.Value.TimeOfDay > TimeSpan.FromHours(9) ? AttendanceStatus.Late : AttendanceStatus.Present;
        await _uow.SaveChangesAsync();
    }

    public async Task CheckOutAsync(int employeeId)
    {
        var today = await GetTodayAsync(employeeId) ?? throw new InvalidOperationException("Check-in not found.");
        today.CheckOutTime = DateTime.UtcNow;
        _uow.Attendances.Update(today);
        await _uow.SaveChangesAsync();
    }
}
