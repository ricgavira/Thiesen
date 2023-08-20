using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class PessoaFisica : BaseEntity<PessoaFisica>
    {
        public PessoaFisica() { }
        public PessoaFisica(string nome, string cpf, string rg, string nomeDaMae, string nomeDoPai, DateTime dataNascimento, byte[]? foto, Raca raca, string naturalidade, string nacionalidade, Sexo sexo)
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
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public Raca Raca { get; set; }
        public Sexo Sexo { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade => CalcularIdade(DataNascimento);
        public byte[]? Foto { get; set; }
        public List<Contato> Contatos { get; set; } = new List<Contato>();
        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();

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

        public void AdicionarContato(Contato contato)
        {
            if (contato == null) return;

            Contatos.Add(contato);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null) return;

            Enderecos.Add(endereco);
        }
    }
}