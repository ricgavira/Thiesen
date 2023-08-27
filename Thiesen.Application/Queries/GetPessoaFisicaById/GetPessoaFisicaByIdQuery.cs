using MediatR;
using Thiesen.Application.Dtos;

namespace Thiesen.Application.Queries.GetPessoaFisicaById
{
    public class GetPessoaFisicaByIdQuery : IRequest<PessoaFisicaDto>
    {
        public GetPessoaFisicaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
