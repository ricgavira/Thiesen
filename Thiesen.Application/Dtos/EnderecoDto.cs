using Thiesen.Domain.Entities;
using Thiesen.Domain.Enums;

namespace Thiesen.Application.Dtos
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Bairro Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public PessoaFisicaDto PessoaFisicaDto { get; set; }
    }
}
