using Thiesen.Domain.Repositories;

namespace Thiesen.Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPessoaFisicaRepository PessoaFisicaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task<int> SaveChangesAsync();
    }
}
