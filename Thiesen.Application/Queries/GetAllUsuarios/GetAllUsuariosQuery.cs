using MediatR;
using Thiesen.Application.Dtos;

namespace Thiesen.Application.Queries.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<List<UsuarioDto>>
    {
    }
}
