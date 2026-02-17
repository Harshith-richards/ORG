using HVACManagement.Repositories.Interfaces;
using HVACManagement.Services.Interfaces;
using HVACManagement.Models.Domain;

namespace HVACManagement.Services.Implementations;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _uow;

    public NotificationService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public Task<IReadOnlyList<Notification>> GetUnreadAsync(string userId)
        => _uow.Notifications.ListAsync(n => n.UserId == userId && !n.IsRead);

    public async Task MarkAsReadAsync(int id)
    {
        var item = await _uow.Notifications.GetByIdAsync(id) ?? throw new InvalidOperationException("Notification not found.");
        item.IsRead = true;
        _uow.Notifications.Update(item);
        await _uow.SaveChangesAsync();
    }

    public async Task PushAsync(string userId, string title, string message, string type = "Info")
    {
        await _uow.Notifications.AddAsync(new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            Type = type,
            IsRead = false
        });

        await _uow.SaveChangesAsync();
    }
}
