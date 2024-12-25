using Domain.Core.Entities;

namespace Domain.Notifications
{
    /// <summary>
    /// Bildirim iş modeli.
    /// </summary>
    public class Notification : BaseEntity
    {
        public Guid InstructionId { get; private set; } // İlgili talimat kimliği
        public string Message { get; private set; }

        // İlişkili kanallar
        public ICollection<NotificationChannelMapping> ChannelMappings { get; private set; } = new List<NotificationChannelMapping>();
        
        private readonly List<NotificationLog> _notificationLogs = new();
        public IReadOnlyCollection<NotificationLog> NotificationLogs => _notificationLogs.AsReadOnly();

        private Notification() { } // EF Core için

        public Notification(Guid instructionId, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Bildirim içeriği boş bırakılamaz!", nameof(message));

            InstructionId = instructionId;
            Message = message;
        }
    }
}
