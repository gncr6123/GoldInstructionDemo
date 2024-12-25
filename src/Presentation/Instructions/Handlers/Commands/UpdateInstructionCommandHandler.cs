using Application.Instructions.Interfaces;
using MediatR;
using Presentation.Instructions.Commands;

namespace Presentation.Instructions.Handlers.Commands
{
    public class UpdateInstructionCommandHandler : IRequestHandler<UpdateInstructionCommand, Unit>
    {
        private readonly IInstructionService _instructionService;

        public UpdateInstructionCommandHandler(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        public async Task<Unit> Handle(UpdateInstructionCommand request, CancellationToken cancellationToken)
        {
            await _instructionService.UpdateInstructionAsync(request.UpdateInstructionDto);

            return Unit.Value;
        }
    }
}
