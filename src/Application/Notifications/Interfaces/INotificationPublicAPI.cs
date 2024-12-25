using Application.Notifications.Dtos;
using Domain.Notifications.Interfaces;

namespace Application.Notifications.Interfaces
{
    public interface INotificationPublicAPI
    {
        Task<Guid> CreateNotificationAsync(CreateNotificationDto createNotificationDto);
        Task SentNotification (Guid notificationId, INotificationUoW uow);
    }
}
