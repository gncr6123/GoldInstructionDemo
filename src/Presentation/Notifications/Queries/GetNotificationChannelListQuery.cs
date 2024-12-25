using Application.Notifications.Dtos;
using MediatR;

namespace Presentation.Notifications.Queries
{
    public class GetNotificationChannelListQuery : IRequest<IEnumerable<NotificationChannelDto>>
    {

    }
}
