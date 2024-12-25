using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Instructions.Commands;
using Presentation.Instructions.Queries;

namespace Presentation.Controllers
{
    /// <summary>
    /// Talep işlemleri ile ilgili API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstructionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Talep oluşturur
        /// </summary>
        /// <returns>Talep ID'si döner</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructionCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        /// <summary>
        /// Talep bilgisini getirir
        /// </summary>
        /// <returns>Talep ID'sinden talep bilgisi döner</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetInstructionByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Kullanıcı ID'sine göre talepleri döner
        /// </summary>
        /// <returns>Kullanıcı talepleri</returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetInstructionList(Guid userId)
        {
            var query = new GetInstructionListQuery { UserId = userId };
            var instructions = await _mediator.Send(query);
            return Ok(instructions);
        }

        /// <summary>
        /// İptal işleminde kullanılır, status alanına 'i' yazılır
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInstructionCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok("Güncelleme başarılı");
        }
    }
}
