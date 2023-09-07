using Thiesen.Domain.Entities;
using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Repositories
{
    public interface IUsuarioRepository : IWriteOnlyRepository<Usuario>, IReadOnlyRepository<Usuario>
    {
        Task<Usuario?> GetUsuarioByLoginAndPasswordAsync(string login, Role role, string passwordHash);
    }
}
