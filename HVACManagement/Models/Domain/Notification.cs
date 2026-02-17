namespace HVACManagement.Models.Domain;

public class Notification : BaseEntity
{
    public int NotificationId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Type { get; set; } = "Info";
    public string UserId { get; set; } = string.Empty;
    public bool IsRead { get; set; }
}
