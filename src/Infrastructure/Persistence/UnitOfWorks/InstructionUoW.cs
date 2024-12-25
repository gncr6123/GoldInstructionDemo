using Domain.Instructions.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWorks
{
    public class InstructionUoW: UoW, IInstructionUoW
    {
        private readonly InstructionDbContext _context;
        private IInstructionRepository _instructionRepository;

        public InstructionUoW(InstructionDbContext context) : base(context)
        {
            _context = context;
        }

        public IInstructionRepository InstructionRepository => _instructionRepository ??= new InstructionRepository(_context);
    }
}
