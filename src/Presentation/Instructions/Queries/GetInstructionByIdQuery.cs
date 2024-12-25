using Application.Instructions.Dtos;
using MediatR;

namespace Presentation.Instructions.Queries
{
    public class GetInstructionByIdQuery:IRequest<InstructionDto>
    {
        public Guid Id { get; set; }
    }
}
