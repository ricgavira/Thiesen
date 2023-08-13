using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class PessoaFisica : BaseEntity<PessoaFisica>
    {
        public PessoaFisica(string nome, string cpf, string rg, string nomeDaMae, string nomeDoPai, DateTime dataNascimento, byte[] foto, Raca raca, string naturalidade, string nacionalidade, Sexo sexo)
        {
            Nome = nome;
            CPF = cpf;
            RG = rg;
            NomeDaMae = nomeDaMae;
            NomeDoPai = nomeDoPai;            
            DataNascimento = dataNascimento;
            Foto = foto;
            Raca = raca;
            Naturalidade = naturalidade;
            Nacionalidade = nacionalidade;
            Sexo = sexo;
            Contatos = new List<Contato>();
            PessoaFisicaEnderecos = new List<PessoaFisicaEndereco>();
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string NomeDaMae { get; private set; }
        public string NomeDoPai { get; private set; }
        public Raca Raca { get; private set; }
        public Sexo Sexo { get; private set; }
        public string Naturalidade { get; private set; }
        public string Nacionalidade { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade => CalcularIdade(DataNascimento);
        public byte[]? Foto { get; private set; }
        public List<Contato> Contatos { get; private set; }
        public List<PessoaFisicaEndereco> PessoaFisicaEnderecos { get; private set; }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
    }
}