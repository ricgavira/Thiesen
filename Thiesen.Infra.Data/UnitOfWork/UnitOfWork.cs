using Microsoft.EntityFrameworkCore.Storage;
using Thiesen.Domain.Repositories;
using Thiesen.Infra.Data.Context;

namespace Thiesen.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(
                AppDbContext appDbContext,
                IPessoaFisicaRepository pessoaFisicaRepository,
                IUsuarioRepository usuarioRepository)
        {
            _appDbContext = appDbContext;
            PessoaFisicaRepository = pessoaFisicaRepository;
            UsuarioRepository = usuarioRepository;
        }

        public IPessoaFisicaRepository PessoaFisicaRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("A transação não foi iniciada.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        { 
            if (disposing)
            {
                _appDbContext.Dispose();
            }
        }
    }
}