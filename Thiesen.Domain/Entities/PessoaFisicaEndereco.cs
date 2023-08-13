namespace Thiesen.Domain.Entities
{
    public class PessoaFisicaEndereco
    {
        public PessoaFisicaEndereco(Endereco endereco, string numero, string referencia, PessoaFisica pessoaFisica)
        {
            Endereco = endereco;
            Numero = numero;
            Referencia = referencia;
            PessoaFisica = pessoaFisica;
        }

        public int PessoaFisicaId { get; private set; }
        public PessoaFisica PessoaFisica { get; private set; }
        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Referencia { get; private set; }
    }
}