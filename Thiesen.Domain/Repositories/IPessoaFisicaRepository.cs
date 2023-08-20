using Thiesen.Domain.Entities;

namespace Thiesen.Domain.Repositories
{
    public interface IPessoaFisicaRepository : IWriteOnlyRepository<PessoaFisica>, IReadOnlyRepository<PessoaFisica>
    {
        Task<IEnumerable<PessoaFisica>> GetByCPFAsync(string CPF);
        Task<IEnumerable<PessoaFisica>> GetByRangeIdadeAsync(int initial, int final);
    }
}
