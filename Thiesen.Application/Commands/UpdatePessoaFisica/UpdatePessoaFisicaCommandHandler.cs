using AutoMapper;
using FluentValidation;
using MediatR;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.UpdatePessoaFisica
{
    public class UpdatePessoaFisicaCommandHandler : IRequestHandler<UpdatePessoaFisicaCommand, Unit>
    {
        private readonly IPessoaFisicaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<PessoaFisicaDto> _validator;

        public UpdatePessoaFisicaCommandHandler(IPessoaFisicaRepository repository, IMapper mapper, IValidator<PessoaFisicaDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdatePessoaFisicaCommand request, CancellationToken cancellationToken)
        {
            //var validationResult = _validator.Validate(request);

            //if (!validationResult.IsValid)
            //    throw new ValidationException(validationResult.Errors);

            var pessoaFisica = await _repository.GetByIdAsync(request.Id);

            if (pessoaFisica == null)
                throw new KeyNotFoundException("Pessoa Física Inexistente!");

            _mapper.Map(request, pessoaFisica);

            await _repository.UpdateAsync(pessoaFisica);

            return Unit.Value;
        }
    }
}