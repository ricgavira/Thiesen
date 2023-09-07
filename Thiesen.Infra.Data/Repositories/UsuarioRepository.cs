using Microsoft.EntityFrameworkCore;
using Thiesen.Domain.Entities;
using Thiesen.Domain.Enums;
using Thiesen.Domain.Repositories;
using Thiesen.Infra.Data.Context;

namespace Thiesen.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _appDbContext.Add(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            _appDbContext.Remove(usuario);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Usuario>> GetAllAsync()
        {
            return await _appDbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _appDbContext.Usuarios
                                      .SingleOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Usuario?> GetUsuarioByLoginAndPasswordAsync(string login, Role role, string passwordHash)
        {
            return await _appDbContext.Usuarios
                                      .SingleOrDefaultAsync(x => x.Login == login && 
                                                                 x.Password == passwordHash &&
                                                                 x.Role == role);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _appDbContext.Update(usuario);
            await _appDbContext.SaveChangesAsync();
        }
    }
}