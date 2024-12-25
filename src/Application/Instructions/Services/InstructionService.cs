using Application.Instructions.Dtos;
using Application.Instructions.Interfaces;
using Application.Notifications.Interfaces;
using Domain.Core.Interfaces;
using Domain.Instructions;
using Domain.Instructions.Interfaces;

namespace Application.Instructions.Services
{
    public class InstructionService : IInstructionService
    {
        private readonly IInstructionUoW _unitOfWork;
        private readonly INotificationPublicAPI _notificationPublicAPI;
        private readonly IScheduler _scheduler;

        public InstructionService(IInstructionUoW unitOfWork, 
            INotificationPublicAPI notificationPublicAPI,
            IScheduler scheduler)
        {
            _unitOfWork = unitOfWork;
            _notificationPublicAPI = notificationPublicAPI;
            _scheduler = scheduler;
        }

        public async Task<Guid> CreateInstructionAsync(CreateInstructionDto instructionDto)
        {
            // Aktif talimat kontrolü
            var hasActiveInstruction = await _unitOfWork.InstructionRepository.HasActiveInstruction(instructionDto.UserId);
            if (hasActiveInstruction)
                throw new InvalidOperationException("Kullanıcının açıkta aktif bir talimatı var.");

            var instruction = new Instruction(instructionDto.UserId, instructionDto.DayOfMonth, instructionDto.Amount);            
            
            await _unitOfWork.InstructionRepository.AddAsync(instruction);
            await _unitOfWork.SaveChangesAsync();

            var notificationId = await _notificationPublicAPI.CreateNotificationAsync
                (new Notifications.Dtos.CreateNotificationDto
                {
                    InstructionId = instruction.Id,
                    Message = "Talebiniz alınmıştır!",
                    NotificationChannels = instructionDto.NotificationChannels,
                });

            await _scheduler.ScheduleAsync(
            jobId: notificationId.ToString(),
            executionTime: new DateTime (DateTime.Now.Year,DateTime.Now.Month,instructionDto.DayOfMonth,14,45,0),
            callback: async (uow) =>
            {                
                await _notificationPublicAPI.SentNotification(notificationId, uow);
            });

            return instruction.Id;
        }

        public Task DeleteInstructionAsync(Guid instructionId)
        {
            throw new NotImplementedException();
        }

        public async Task<InstructionDto> GetInstructionByIdAsync(Guid instructionId)
        {
            
            var instruction = await _unitOfWork.InstructionRepository.GetByIdAsync(instructionId);
            if (instruction == null)
                throw new Exception("İlgili ID'de talimat bulunamadı!");
            
            return new InstructionDto
            {
                Id = instruction.Id,
                UserId = instruction.UserId,
                DayOfMonth = instruction.DayOfMonth,
                Amount = instruction.Amount,
                NotificationChannels = new List<string>(),
                Status = instruction.Status.ToString()
            };
        }

        public async Task<IEnumerable<InstructionDto>> GetInstructionListAsync(Guid userId)
        {
            
            var instructions = await _unitOfWork.InstructionRepository.FindAsync(u=>u.UserId == userId);
            
            return instructions.Select(instruction => new InstructionDto
            {
                Id = instruction.Id,
                UserId = instruction.UserId,
                DayOfMonth = instruction.DayOfMonth,
                Amount = instruction.Amount,
                NotificationChannels = new List<string>(),
                Status = instruction.Status.ToString()
            });
        }
        
        public async Task UpdateInstructionAsync(UpdateInstructionDto instructionDto)
        {
            
            var instruction = await _unitOfWork.InstructionRepository.GetByIdAsync(instructionDto.Id);
            if (instruction == null)
                throw new Exception("Talimat bulunamadı.");

            if (instructionDto.Status.Equals("i"))
                instruction.Cancel();
            else if (instructionDto.Status.Equals("r"))
                instruction.Reset();
            
            await _unitOfWork.InstructionRepository.UpdateAsync(instruction);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
