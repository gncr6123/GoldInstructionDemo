namespace Application.Notifications.Dtos
{
    public class CreateNotificationDto
    {
        public Guid InstructionId { get; set; }
        public string Message { get; set; }
        public List<string> NotificationChannels { get; set; }
    }
}
