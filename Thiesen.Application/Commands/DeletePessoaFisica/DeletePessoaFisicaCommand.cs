using MediatR;

namespace Thiesen.Application.Commands.DeletePessoaFisica
{
    public class DeletePessoaFisicaCommand : IRequest<Unit>
    {
        public DeletePessoaFisicaCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}