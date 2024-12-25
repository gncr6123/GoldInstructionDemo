using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Notifications.Queries;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Bildirim kanallarını listeler
        /// </summary>
        /// <returns>Talep ID'si döner</returns>
        [HttpGet(Name ="channel-list")]
        public async Task<IActionResult> GetNotificationChannelList()
        {
            var query = new GetNotificationChannelListQuery();
            var notificationChannels = await _mediator.Send(query);
            return Ok(notificationChannels);
        }
    }
}
