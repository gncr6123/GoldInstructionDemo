using Domain.Core.Entities;

namespace Domain.Notifications
{
    /// <summary>
    /// Bildirim kanalı modeli.
    /// </summary>
    public class NotificationChannel : BaseEntity
    {
        public string Name { get; private set; }

        private NotificationChannel() { } // EF Core için

        public NotificationChannel(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Bildirim kanalı ismi boş bırakılamaz", nameof(name));

            Name = name;
        }
    }
}
