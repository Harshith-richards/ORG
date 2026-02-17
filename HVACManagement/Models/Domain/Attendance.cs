using HVACManagement.Models.Enums;

namespace HVACManagement.Models.Domain;

public class Attendance : BaseEntity
{
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public int? ProjectId { get; set; }
    public DateOnly Date { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Absent;

    public Employee? Employee { get; set; }
    public Project? Project { get; set; }
}
