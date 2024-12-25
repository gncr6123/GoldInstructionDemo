using Application.Instructions.Dtos;
using MediatR;

namespace Presentation.Instructions.Commands
{
    public class CreateInstructionCommand:IRequest<Guid>
    {
        public CreateInstructionDto CreateInstructionDto { get; set; }
    }
}
