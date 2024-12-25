using Domain.Instructions;
using Domain.Instructions.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        private readonly InstructionDbContext _context;

        public InstructionRepository(InstructionDbContext context) : base (context)
        {
            _context = context;            
        }

        public async Task<bool> HasActiveInstruction(Guid UserId)
        {
            return await _context.Instructions
                .AnyAsync(t => t.UserId == UserId && t.Status == InstructionStatus.Active);
        }
    }
}
