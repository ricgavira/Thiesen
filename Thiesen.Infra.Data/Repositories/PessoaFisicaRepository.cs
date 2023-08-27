using Microsoft.EntityFrameworkCore;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Repositories;
using Thiesen.Infra.Data.Context;

namespace Thiesen.Infra.Data.Repositories
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly AppDbContext _appDbContext;

        public PessoaFisicaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PessoaFisica> AddAsync(PessoaFisica pessoaFisica)
        {
            _appDbContext.Add(pessoaFisica);
            await _appDbContext.SaveChangesAsync();
            return pessoaFisica;
        }

        public async Task DeleteAsync(PessoaFisica pessoaFisica)
        {
            _appDbContext.Remove(pessoaFisica);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<PessoaFisica>> GetAllAsync()
        {
            return await _appDbContext.PessoasFisicas
                                      .ToListAsync();
        }

        public async Task<IEnumerable<PessoaFisica>> GetByCPFAsync(string CPF)
        {
            return await _appDbContext.PessoasFisicas
                                      .Where(x => x.Cpf == CPF)
                                      .ToListAsync();
        }

        public async Task<PessoaFisica?> GetByIdAsync(int id)
        {
            return await _appDbContext.PessoasFisicas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PessoaFisica>> GetByRangeIdadeAsync(int initial, int final)
        {
            return await _appDbContext.PessoasFisicas
                                      .Where(x => x.Idade >= initial && x.Idade <= final)
                                      .ToListAsync();
        }

        public async Task UpdateAsync(PessoaFisica pessoaFisica)
        {
            _appDbContext.Update(pessoaFisica);
            await _appDbContext.SaveChangesAsync();
        }
    }
}