using Application.Notifications.Dtos;

namespace Application.Notifications.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationChannelDto>> GetNotificationChannelListAsync();
    }
}
