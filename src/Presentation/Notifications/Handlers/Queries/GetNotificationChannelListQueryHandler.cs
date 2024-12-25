using Application.Notifications.Dtos;
using Application.Notifications.Interfaces;
using MediatR;
using Presentation.Notifications.Queries;

namespace Presentation.Notifications.Handlers.Queries
{
    public class GetNotificationChannelListQueryHandler: IRequestHandler<GetNotificationChannelListQuery, IEnumerable<NotificationChannelDto>>
    {
        private readonly INotificationService _notificationService;

        public GetNotificationChannelListQueryHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<NotificationChannelDto>> Handle(GetNotificationChannelListQuery request, CancellationToken cancellationToken)
        {
            return await _notificationService.GetNotificationChannelListAsync();
        }
    }
}
