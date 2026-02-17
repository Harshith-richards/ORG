using HVACManagement.Models.Enums;

namespace HVACManagement.Models.Domain;

public class Project : BaseEntity
{
    public int ProjectId { get; set; }
    public string ProjectCode { get; set; } = string.Empty;
    public string ProjectName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public int ProgressPercentage { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planning;

    public Client? Client { get; set; }
    public ICollection<ProjectAssignment> ProjectAssignments { get; set; } = new List<ProjectAssignment>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
