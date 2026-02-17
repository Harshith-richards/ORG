using HVACManagement.Models.Domain;

namespace HVACManagement.Services.Interfaces;

public interface INotificationService
{
    Task<IReadOnlyList<Notification>> GetUnreadAsync(string userId);
    Task MarkAsReadAsync(int id);
    Task PushAsync(string userId, string title, string message, string type = "Info");
}
