using Application.Instructions.Dtos;

namespace Application.Instructions.Interfaces
{
    public interface IInstructionService
    {
        Task<Guid> CreateInstructionAsync(CreateInstructionDto instructionDto);
        Task UpdateInstructionAsync(UpdateInstructionDto instructionDto);
        Task DeleteInstructionAsync(Guid instructionId);
        Task<InstructionDto> GetInstructionByIdAsync(Guid instructionId);
        Task<IEnumerable<InstructionDto>> GetInstructionListAsync(Guid userId);
    }
}
