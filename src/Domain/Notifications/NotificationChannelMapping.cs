namespace Domain.Notifications
{
    /// <summary>
    /// Bildirim ve kanal arasındaki ilişki tablosu.
    /// </summary>
    public class NotificationChannelMapping
    {
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }

        public Guid ChannelId { get; set; }
        public NotificationChannel Channel { get; set; }

        public bool IsSent { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
