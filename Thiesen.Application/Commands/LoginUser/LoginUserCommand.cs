using MediatR;
using Thiesen.Application.Dtos;

namespace Thiesen.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UsuarioLoginDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}