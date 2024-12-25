namespace Domain.Notifications
{
    /// <summary>
    /// Bildirim log modeli
    /// </summary>
    public class NotificationLog
    {
        
        public Guid Id { get; private set; }        
        public Guid NotificationId { get; private set; }
        public Guid ChannelId { get; private set; }      
        public bool IsSent { get; private set; }
        public DateTime? SentAt { get; private set; }
        public string? ErrorMessage { get; private set; }        
        public Notification Notification { get; private set; }
        public NotificationChannel Channel { get; private set; }
        
        private NotificationLog() { } // For EF Core

        public NotificationLog(Guid notificationId, Guid channelId)
        {
            Id = Guid.NewGuid();
            NotificationId = notificationId;
            ChannelId = channelId;
            IsSent = false;
        }

        public void SetSuccess()
        {
            IsSent = true;
        }

        public void SetFail()
        {
            IsSent = false;
        }


    }
}
