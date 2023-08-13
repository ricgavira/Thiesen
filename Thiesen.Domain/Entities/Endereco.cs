using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class Endereco : BaseEntity<Endereco>
    {
        public Endereco(string nome, TipoEndereco tipoEndereco, string cep, Bairro bairro)
        {
            Nome = nome;
            TipoEndereco = tipoEndereco;
            CEP = cep;
            Bairro = bairro;
            PessoaFisicaEnderecos = new List<PessoaFisicaEndereco>();
        }

        public string Nome { get; private set; }
        public Bairro Bairro { get; private set; }
        public string CEP { get; private set; }
        public TipoEndereco TipoEndereco { get; private set; }
        public List<PessoaFisicaEndereco> PessoaFisicaEnderecos { get; private set; }
    }
}