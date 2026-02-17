using Microsoft.AspNetCore.Identity;

namespace HVACManagement.Models.Domain;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Department { get; set; }
    public string? EmployeeCode { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public string FullName => $"{FirstName} {LastName}".Trim();
}
