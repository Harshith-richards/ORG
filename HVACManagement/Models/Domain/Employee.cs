namespace HVACManagement.Models.Domain;

public class Employee : BaseEntity
{
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string ApplicationUserId { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public decimal Salary { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public Department? Department { get; set; }
    public ICollection<ProjectAssignment> ProjectAssignments { get; set; } = new List<ProjectAssignment>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
