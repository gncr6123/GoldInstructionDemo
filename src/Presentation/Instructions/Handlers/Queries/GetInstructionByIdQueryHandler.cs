using Application.Instructions.Dtos;
using Application.Instructions.Interfaces;
using MediatR;
using Presentation.Instructions.Queries;

namespace Presentation.Instructions.Handlers.Queries
{

    public class GetInstructionByIdQueryHandler : IRequestHandler<GetInstructionByIdQuery, InstructionDto>
    {
        private readonly IInstructionService _instructionService;

        public GetInstructionByIdQueryHandler(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        public async Task<InstructionDto> Handle(GetInstructionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _instructionService.GetInstructionByIdAsync(request.Id);
        }
    }

}
