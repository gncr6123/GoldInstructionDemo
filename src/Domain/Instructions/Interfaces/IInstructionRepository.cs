using Domain.Core.Interfaces;

namespace Domain.Instructions.Interfaces
{
    public interface IInstructionRepository : IRepository<Instruction>
    {
        Task<bool> HasActiveInstruction(Guid UserId);
    }
}
