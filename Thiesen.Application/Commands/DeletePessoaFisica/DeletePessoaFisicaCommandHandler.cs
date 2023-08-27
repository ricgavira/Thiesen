using MediatR;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.DeletePessoaFisica
{
    public class DeletePessoaFisicaCommandHandler : IRequestHandler<DeletePessoaFisicaCommand, Unit>
    {
        private readonly IPessoaFisicaRepository _repository;

        public DeletePessoaFisicaCommandHandler(IPessoaFisicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisica = await _repository.GetByIdAsync(request.Id);

            if (pessoaFisica == null)
                throw new KeyNotFoundException("Pessoa Física Inexistente!");

            await _repository.DeleteAsync(pessoaFisica);

            return Unit.Value;
        }
    }
}
