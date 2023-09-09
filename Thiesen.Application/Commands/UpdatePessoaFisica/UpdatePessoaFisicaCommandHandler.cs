using AutoMapper;
using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.UpdatePessoaFisica
{
    public class UpdatePessoaFisicaCommandHandler : IRequestHandler<UpdatePessoaFisicaCommand, Unit>
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePessoaFisicaCommandHandler(IPessoaFisicaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var pessoaFisica = await _repository.GetByIdAsync(request.Id);

            if (pessoaFisica == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundPessoaFisica);

            _mapper.Map(request, pessoaFisica);

            await _repository.UpdateAsync(pessoaFisica);

            return Unit.Value;
        }
    }
}