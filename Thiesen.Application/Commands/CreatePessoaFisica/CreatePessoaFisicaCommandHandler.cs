using AutoMapper;
using FluentValidation;
using MediatR;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.CreatePessoaFisica
{
    public class CreatePessoaFisicaCommandHandler : IRequestHandler<CreatePessoaFisicaCommand, int>
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatePessoaFisicaCommand> _validator;

        public CreatePessoaFisicaCommandHandler(IPessoaFisicaRepository repository, IMapper mapper, IValidator<CreatePessoaFisicaCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var pessoaFisica = _mapper.Map<PessoaFisica>(request);

            var retorno = await _repository.AddAsync(pessoaFisica);

            return retorno.Id;
        }
    }
}