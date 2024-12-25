using Application.Instructions.Interfaces;
using MediatR;
using Presentation.Instructions.Commands;

namespace Presentation.Instructions.Handlers.Commands
{
    public class CreateInstructionCommandHandler : IRequestHandler<CreateInstructionCommand, Guid>
    {
        private readonly IInstructionService _instructionService;

        public CreateInstructionCommandHandler(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        public async Task<Guid> Handle(CreateInstructionCommand request, CancellationToken cancellationToken)
        {
            return await _instructionService.CreateInstructionAsync(request.CreateInstructionDto);
        }
    }
}
