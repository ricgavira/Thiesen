using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.DeletePessoaFisica
{
    public class DeletePessoaFisicaCommandHandler : IRequestHandler<DeletePessoaFisicaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePessoaFisicaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisica = await _unitOfWork.PessoaFisicaRepository.GetByIdAsync(request.Id);

            if (pessoaFisica == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundPessoaFisica);

            await _unitOfWork.PessoaFisicaRepository.DeleteAsync(pessoaFisica);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}