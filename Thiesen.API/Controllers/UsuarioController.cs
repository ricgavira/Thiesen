using MediatR;
using Microsoft.AspNetCore.Mvc;
using Thiesen.Application.Commands.CreateUsuario;
using Thiesen.Application.Commands.DeleteUsuario;
using Thiesen.Application.Commands.LoginUser;
using Thiesen.Application.Commands.UpdateUsuario;
using Thiesen.Application.Queries.GetAllUsuarios;
using Thiesen.Application.Queries.GetUsuarioById;
using Thiesen.Application.Resources;

namespace Thiesen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUsuarioCommand command)
        { 
            var id = _mediator.Send(command);
            return CreatedAtAction(nameof(GetAsync), new { id }, command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteUsuarioCommand(id);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllUsuariosQuery();
            var usuariosDto = await _mediator.Send(query);
            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetUsuarioByIdQuery(id);
            var usuarioDto = await _mediator.Send(query);

            if (usuarioDto == null)
                return NotFound();

            return Ok(usuarioDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUsuarioCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginDto = await _mediator.Send(command);

            if (loginDto == null)
                return BadRequest(ValidationMessages.InvalidLogin);

            return Ok(loginDto);
        }
    }
}