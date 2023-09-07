using MediatR;
using Thiesen.Application.Dtos;
using Thiesen.Domain.Enums;

namespace Thiesen.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UsuarioLoginDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}