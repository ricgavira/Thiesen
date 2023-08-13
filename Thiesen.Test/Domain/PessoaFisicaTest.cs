using Thiesen.Domain.Entities;
using Thiesen.Domain.Enums;

namespace Thiesen.Test.Domain
{
    public class PessoaFisicaTest
    {
        private readonly string nome = "Ricardo";
        private readonly string cpf = "11111111111";
        private readonly string nomeMae = "Mae";
        private readonly string nomePai = "Pai";
        private readonly string rg = "0000000";
        private readonly string naturalidade = "Cidade";
        private readonly string nacionalidade = "Brasileira";
        private DateTime dataNascimento;


        [Fact(DisplayName = "Deve criar pessoa física")]
        public void DevePessoaFisica()
        {
            dataNascimento = new DateTime(1970, 5, 20);
            var endereco = new Endereco("Rua da Divisão", TipoEndereco.Residencial, "79100000", new Bairro("Bairro", new Cidade("Cidade", new Estado("Estado", "MS"))));
            var pessoaFisica = new PessoaFisica(nome, cpf, rg, nomeMae, nomePai, dataNascimento, null, Raca.Pardo, naturalidade, nacionalidade, Sexo.Masculino);

            var pessoaFisicaEndereco = new PessoaFisicaEndereco(endereco, "10", "Esquina", pessoaFisica);

            pessoaFisica.PessoaFisicaEnderecos.Add(pessoaFisicaEndereco);

            var contato = new Contato("Telefone Celular", TipoContato.Celular, "Ricardo");
            pessoaFisica.Contatos.Add(contato);

            Assert.NotNull(pessoaFisica);
            Assert.Equal(pessoaFisica.Nome, nome);
            Assert.True(pessoaFisica.Contatos.Count() == 1);
        }
    }
}