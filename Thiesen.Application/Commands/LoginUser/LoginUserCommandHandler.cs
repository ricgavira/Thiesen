using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Thiesen.Application.Dtos;
using Thiesen.Application.Resources;
using Thiesen.Domain.Repositories;
using Thiesen.Domain.Services;

namespace Thiesen.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UsuarioLoginDto>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IAuthService authService, IUsuarioRepository repository, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioLoginDto?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputedSha256Hash(request.Password);

            var usuario = await _repository.GetUsuarioByLoginAndPasswordAsync(request.Login, passwordHash);

            if (usuario == null)
                return null;

            var token = _authService.GenerateJwtToken(usuario.Login, usuario.Role.ToString());

            return new UsuarioLoginDto(usuario.Login, token);
        }
    }
}