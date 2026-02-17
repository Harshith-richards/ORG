namespace HVACManagement.Models.Domain;

public class ProjectAssignment : BaseEntity
{
    public int ProjectAssignmentId { get; set; }
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }
    public string Role { get; set; } = "Support";
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

    public Project? Project { get; set; }
    public Employee? Employee { get; set; }
}
