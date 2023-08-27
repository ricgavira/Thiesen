using MediatR;
using Microsoft.AspNetCore.Mvc;
using Thiesen.Application.Commands.CreatePessoaFisica;
using Thiesen.Application.Commands.DeletePessoaFisica;
using Thiesen.Application.Commands.UpdatePessoaFisica;
using Thiesen.Application.Queries.GetAllPessoasFisicas;
using Thiesen.Application.Queries.GetPessoaFisicaById;

namespace Thiesen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaFisicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePessoaFisicaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAsync), new { id = id }, command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCommand = new DeletePessoaFisicaCommand(id);
            await _mediator.Send(deleteCommand);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllPessoasFisicasQuery();
            var pessoasFisicasDto = await _mediator.Send(query);
            return Ok(pessoasFisicasDto.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var query = new GetPessoaFisicaByIdQuery(id);
            var pessoaFisicaDto = await _mediator.Send(query);

            if (pessoaFisicaDto == null)
                return NotFound();

            return Ok(pessoaFisicaDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePessoaFisicaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
