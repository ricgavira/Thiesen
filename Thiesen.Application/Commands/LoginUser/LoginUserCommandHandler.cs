using MediatR;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Services;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UsuarioLoginDto?>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UsuarioLoginDto?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputedSha256Hash(request.Password);

            var usuario = await _unitOfWork.UsuarioRepository.GetUsuarioByLoginAndPasswordAsync(request.Login, passwordHash);

            if (usuario == null)
                return null;

            var token = _authService.GenerateJwtToken(usuario.Login, usuario.Role.ToString());

            return new UsuarioLoginDto(usuario.Login, token);
        }
    }
}