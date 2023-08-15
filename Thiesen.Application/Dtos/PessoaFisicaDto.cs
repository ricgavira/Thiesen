using Thiesen.Domain.Enums;

namespace Thiesen.Application.Dtos
{
    public class PessoaFisicaDto
    {
        public PessoaFisicaDto(string nome, string cpf, string rg, string nomeDaMae, string nomeDoPai, DateTime dataNascimento, byte[]? foto, Raca raca, string naturalidade, string nacionalidade, Sexo sexo)
        {
            Nome = nome;
            CPF = cpf;
            RG = rg;
            NomeDaMae = nomeDaMae;
            NomeDoPai = nomeDoPai;
            Raca = raca;
            Sexo = sexo;
            Naturalidade = naturalidade;
            Nacionalidade = nacionalidade;
            DataNascimento = dataNascimento;
            Foto = foto;
        }

        public int Id { get; set; }
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
        public byte[]? Foto { get; set; }
        public List<ContatoDto>? ContatosDto { get; set; }
        public List<PessoaFisicaEnderecoDto>? PessoaFisicaEnderecosDto { get; set; }
    }
}