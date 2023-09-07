using AutoMapper;
using FluentValidation;
using MediatR;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;
using Thiesen.Domain.Services;

namespace Thiesen.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUsuarioCommand> _validator;
        private readonly IAuthService _authService;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper, IValidator<CreateUsuarioCommand> validator, IAuthService authService)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            request.Password = _authService.ComputedSha256Hash(request.Password);

            var usuario = _mapper.Map<Usuario>(request);

            var retorno = await _repository.AddAsync(usuario);

            return retorno.Id;
        }
    }
}