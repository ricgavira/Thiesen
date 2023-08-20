using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class Endereco : BaseEntity<Endereco>
    {
        public Endereco(string nome, TipoEndereco tipoEndereco, string cep, Bairro bairro, string numero)
        {
            Nome = nome;
            TipoEndereco = tipoEndereco;
            CEP = cep;
            Bairro = bairro;
            PessoaFisica = new PessoaFisica();
            Numero = numero;
        }

        public string Nome { get; private set; }
        public Bairro Bairro { get; private set; }
        public string Numero { get; private set; }
        public string CEP { get; private set; }
        public TipoEndereco TipoEndereco { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
    }
}