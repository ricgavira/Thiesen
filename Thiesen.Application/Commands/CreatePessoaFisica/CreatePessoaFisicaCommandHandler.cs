using AutoMapper;
using MediatR;
using Thiesen.Application.Helpers;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Helpers;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.CreatePessoaFisica
{
    public class CreatePessoaFisicaCommandHandler : IRequestHandler<CreatePessoaFisicaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePessoaFisicaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisicaExiste = await _unitOfWork.PessoaFisicaRepository.GetByCPFAsync(StringHelper.OnlyNumber(request?.CPF ?? ""));

            if (!pessoaFisicaExiste.Any())
                return -1;

            var pessoaFisica = _mapper.Map<PessoaFisica>(request);

            await _unitOfWork.BeginTransactionAsync();
            var retorno = await _unitOfWork.PessoaFisicaRepository.AddAsync(pessoaFisica);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            return retorno.Id;
        }
    }
}