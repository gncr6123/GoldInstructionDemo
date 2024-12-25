using Application.Instructions.Dtos;
using MediatR;

namespace Presentation.Instructions.Commands
{
    public class UpdateInstructionCommand: IRequest<Unit>
    {
        public UpdateInstructionDto UpdateInstructionDto { get; set; }
    }
}
