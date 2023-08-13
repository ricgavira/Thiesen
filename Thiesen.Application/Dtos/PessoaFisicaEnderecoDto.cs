using Thiesen.Domain.Entities;

namespace Thiesen.Application.Dtos
{
    public class PessoaFisicaEnderecoDto
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public PessoaFisicaDto PessoaFisicaDto { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }
    }
}
