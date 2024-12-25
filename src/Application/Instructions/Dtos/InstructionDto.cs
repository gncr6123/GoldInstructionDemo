namespace Application.Instructions.Dtos
{
    public class InstructionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int DayOfMonth { get; set; }
        public decimal Amount { get; set; }
        public List<string> NotificationChannels { get; set; }
        public string Status { get; set; }
    }
}
