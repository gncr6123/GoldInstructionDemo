using Domain.Notifications.Interfaces;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.UnitOfWorks
{
    public class NotificationUoW:UoW,INotificationUoW
    {
        private readonly NotificationDbContext _context;

        public NotificationUoW(NotificationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
