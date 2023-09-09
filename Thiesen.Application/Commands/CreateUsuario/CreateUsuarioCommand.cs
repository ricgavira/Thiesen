using MediatR;
using Thiesen.Domain.Enums;

namespace Thiesen.Application.Commands.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
