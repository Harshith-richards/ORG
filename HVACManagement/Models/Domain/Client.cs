namespace HVACManagement.Models.Domain;

public class Client : BaseEntity
{
    public int ClientId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string PrimaryContactName { get; set; } = string.Empty;
    public string PrimaryContactEmail { get; set; } = string.Empty;
    public string PrimaryContactPhone { get; set; } = string.Empty;

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
