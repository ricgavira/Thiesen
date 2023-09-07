using AutoMapper;
using FluentValidation;
using MediatR;
using Thiesen.Application.Resources;
using Thiesen.Domain.Repositories;

namespace Thiesen.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUsuarioCommand> _validator;

        public UpdateUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper, IValidator<UpdateUsuarioCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var usuario = await _repository.GetByIdAsync(request.Id);

            if (usuario == null)
                throw new KeyNotFoundException(ValidationMessages.NotFoundUsuario);

            _mapper.Map(request, usuario);

            await _repository.UpdateAsync(usuario);

            return Unit.Value;

        }
    }
}