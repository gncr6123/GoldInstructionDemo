namespace Application.Instructions.Dtos
{
    public class CreateInstructionDto
    {
        public Guid UserId { get; set; }
        public int DayOfMonth { get; set; }
        public decimal Amount { get; set; }
        public List<string> NotificationChannels { get; set; }
    }
}
