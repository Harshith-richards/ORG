using HVACManagement.Models.Domain;

namespace HVACManagement.Services.Interfaces;

public interface IAttendanceService
{
    Task<Attendance?> GetTodayAsync(int employeeId);
    Task CheckInAsync(int employeeId);
    Task CheckOutAsync(int employeeId);
}
