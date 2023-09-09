using AutoMapper;
using MediatR;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.CreatePessoaFisica
{
    public class CreatePessoaFisicaCommandHandler : IRequestHandler<CreatePessoaFisicaCommand, int>
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public CreatePessoaFisicaCommandHandler(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisica = _mapper.Map<PessoaFisica>(request);

            var retorno = await _repository.AddAsync(pessoaFisica);

            return retorno.Id;
        }
    }
}