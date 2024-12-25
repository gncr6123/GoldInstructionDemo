using Application.Notifications.Dtos;
using Application.Notifications.Interfaces;
using Domain.Notifications;
using Domain.Notifications.Interfaces;

namespace Application.Notifications.Services
{
    public class NotificationPublicAPI: INotificationPublicAPI
    {
        private readonly INotificationUoW _unitOfWork;

        public NotificationPublicAPI(INotificationUoW unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateNotificationAsync(CreateNotificationDto createNotificationDto)
        {
                       
            var notification = new Notification(createNotificationDto.InstructionId,createNotificationDto.Message);
            await _unitOfWork.Repository<Notification>().AddAsync(notification);

            foreach (var channel in createNotificationDto.NotificationChannels)
            {
                var notificationChannelMapping = new NotificationChannelMapping
                {
                    ChannelId = channel.Equals("SMS") ? new Guid("061898E6-C619-4F9E-96FC-F517E18F1FE7")
                    : channel.Equals("EMAIL") ? new Guid("CF7D73AA-C172-4EB2-9782-5491C76018B9")
                    : channel.Equals("PUSH") ? new Guid("829FE06A-2FA2-477C-979D-D1080CA86BBC") : Guid.NewGuid(),
                    NotificationId = notification.Id
                };
                await _unitOfWork.Repository<NotificationChannelMapping>().AddAsync(notificationChannelMapping);
            }

            await _unitOfWork.SaveChangesAsync();

            return notification.Id;
        }

        public async Task SentNotification(Guid notificationId, INotificationUoW notificationUoW)
        {
            var mappings = await notificationUoW.Repository<NotificationChannelMapping>().FindAsync(ch => ch.NotificationId == notificationId);

            foreach (var mapping in mappings)
            {

                var notificationLog = new NotificationLog(notificationId, mapping.ChannelId);

                if(mapping.ChannelId == new Guid("061898E6-C619-4F9E-96FC-F517E18F1FE7"))
                {
                    // Sent SMS
                    notificationLog.SetSuccess();
                }
                
                if (mapping.ChannelId == new Guid("CF7D73AA-C172-4EB2-9782-5491C76018B9"))
                {
                    // Sent EMAIL
                    notificationLog.SetSuccess();
                } 
                
                if (mapping.ChannelId == new Guid("829FE06A-2FA2-477C-979D-D1080CA86BBC")) 
                {
                    // Sent PUSH
                    notificationLog.SetSuccess();
                }

                await notificationUoW.Repository<NotificationLog>().AddAsync(notificationLog);

            }

            await notificationUoW.SaveChangesAsync();

        }        
    }
}
