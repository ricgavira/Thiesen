using Thiesen.Application.Dtos;

namespace Thiesen.Application.Services.Interfaces
{
    public interface IPessoaFisicaService
    {
        Task<PessoaFisicaDto> GetByIdAsync(int id);
        Task<IEnumerable<PessoaFisicaDto>> GetAllAsync();
        Task<PessoaFisicaDto> CreateAsync(PessoaFisicaDto pessoaFisicaDto);
        Task UpdateAsync(PessoaFisicaDto pessoaFisicaDto);
        Task DeleteAsync(int id);
    }
}
