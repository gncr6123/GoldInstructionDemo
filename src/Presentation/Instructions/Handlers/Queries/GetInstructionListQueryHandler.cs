using Application.Instructions.Dtos;
using Application.Instructions.Interfaces;
using MediatR;
using Presentation.Instructions.Queries;

namespace Presentation.Instructions.Handlers.Queries
{
    public class GetInstructionListQueryHandler : IRequestHandler<GetInstructionListQuery, IEnumerable<InstructionDto>>
    {
        private readonly IInstructionService _instructionService;

        public GetInstructionListQueryHandler(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        public async Task<IEnumerable<InstructionDto>> Handle(GetInstructionListQuery request, CancellationToken cancellationToken)
        {
            return await _instructionService.GetInstructionListAsync(request.UserId);
        }
    }
}
