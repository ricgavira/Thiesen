using AutoMapper;
using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.UpdatePessoaFisica
{
    public class UpdatePessoaFisicaCommandHandler : IRequestHandler<UpdatePessoaFisicaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePessoaFisicaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisica = await _unitOfWork.PessoaFisicaRepository.GetByIdAsync(request.Id);

            if (pessoaFisica == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundPessoaFisica);

            _mapper.Map(request, pessoaFisica);

            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.PessoaFisicaRepository.UpdateAsync(pessoaFisica);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return Unit.Value;
        }
    }
}