using Application.Notifications.Dtos;
using Application.Notifications.Interfaces;
using Domain.Notifications;
using Domain.Notifications.Interfaces;

namespace Application.Notifications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationUoW _unitOfWork;

        public NotificationService(INotificationUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationChannelDto>> GetNotificationChannelListAsync()
        {
            var notificationChannels = await _unitOfWork.Repository<NotificationChannel>().GetAllAsync();

            return notificationChannels.Select(channel => new NotificationChannelDto
            {
                Id = channel.Id,
                Name = channel.Name
            });
        }
    }
}
