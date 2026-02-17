namespace HVACManagement.Models.Domain;

public class Department : BaseEntity
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
