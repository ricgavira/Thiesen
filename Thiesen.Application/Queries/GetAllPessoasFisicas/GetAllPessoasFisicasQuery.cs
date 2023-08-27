using MediatR;
using Thiesen.Application.Dtos;

namespace Thiesen.Application.Queries.GetAllPessoasFisicas
{
    public class GetAllPessoasFisicasQuery : IRequest<List<PessoaFisicaDto>>
    {
    }
}