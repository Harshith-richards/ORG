using System.ComponentModel.DataAnnotations;
using HVACManagement.Models.Enums;

namespace HVACManagement.ViewModels.Project;

public class ProjectCreateViewModel
{
    [Required, StringLength(120)]
    public string ProjectName { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string ProjectCode { get; set; } = string.Empty;

    [Required]
    public int ClientId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime DeadlineDate { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Budget { get; set; }

    public string Description { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; } = ProjectStatus.Planning;
}
