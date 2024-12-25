using Domain.Core.Interfaces;

namespace Domain.Instructions.Interfaces
{
    public interface IInstructionUoW : IUnitOfWork
    {
        IInstructionRepository InstructionRepository { get; }
    }
}
