namespace HVACManagement.Models.Domain;

public abstract class BaseEntity
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
    public string? CreatedById { get; set; }
    public string? ModifiedById { get; set; }
    public bool IsActive { get; set; } = true;
}
