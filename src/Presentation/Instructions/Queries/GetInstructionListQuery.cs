using Application.Instructions.Dtos;
using MediatR;

namespace Presentation.Instructions.Queries
{
    public class GetInstructionListQuery:IRequest<IEnumerable<InstructionDto>>
    {
        public Guid UserId { get; set; }
    }
}
