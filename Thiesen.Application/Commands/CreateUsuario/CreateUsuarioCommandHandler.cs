using AutoMapper;
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
        private readonly IAuthService _authService;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper, IAuthService authService)
        {
            _repository = repository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            bool usuarioExiste = await _repository.GetByLoginAsync(request.Login);

            if (usuarioExiste)
                return -1;

            request.Password = _authService.ComputedSha256Hash(request.Password);

            var usuario = _mapper.Map<Usuario>(request);

            var retorno = await _repository.AddAsync(usuario);

            return retorno.Id;
        }
    }
}