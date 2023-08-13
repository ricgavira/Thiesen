using Thiesen.Domain.Entities;

namespace Thiesen.Domain.Repositories
{
    public interface IPessoaFisicaRepository : IBaseRepository<PessoaFisica>
    {
        Task<IEnumerable<PessoaFisica>> GetByCPFAsync(string CPF);
        Task<IEnumerable<PessoaFisica>> GetByRangeIdadeAsync(int initial, int final);
    }
}
