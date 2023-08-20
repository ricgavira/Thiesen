using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities.Builders
{
    public class PessoaFisicaBuilder
    {
        private PessoaFisica _pessoaFisica;

        public PessoaFisicaBuilder()
        {
            Novo();
        }

        public PessoaFisica Novo()
        {
            _pessoaFisica = new PessoaFisica();
            return _pessoaFisica;
        }

        public PessoaFisica ComNome(string nome)
        {
            _pessoaFisica.Nome = nome;
            return _pessoaFisica;
        }

        public PessoaFisica ComCPF(string cpf)
        {
            _pessoaFisica.CPF = cpf;
            return _pessoaFisica;
        }

        public PessoaFisica ComRG(string rg)
        {
            _pessoaFisica.RG = rg;
            return _pessoaFisica;
        }

        public PessoaFisica ComNomeDaMae(string nomeDaMae)
        {
            _pessoaFisica.NomeDaMae = nomeDaMae;
            return _pessoaFisica;
        }

        public PessoaFisica ComNomeDoPai(string nomeDoPai)
        {
            _pessoaFisica.NomeDoPai = nomeDoPai;
            return _pessoaFisica;
        }

        public PessoaFisica ComDataNascimento(DateTime dataNascimento)
        {
            _pessoaFisica.DataNascimento = dataNascimento;
            return _pessoaFisica;
        }

        public PessoaFisica ComFoto(byte[] foto)
        {
            _pessoaFisica.Foto = foto;
            return _pessoaFisica;
        }

        public PessoaFisica ComRaca(Raca raca)
        {
            _pessoaFisica.Raca = raca;
            return _pessoaFisica;
        }

        public PessoaFisica ComNaturalidade(string naturalidade)
        {
            _pessoaFisica.Naturalidade = naturalidade;
            return _pessoaFisica;
        }

        public PessoaFisica ComNacionalidade(string nacionalidade)
        {
            _pessoaFisica.Nacionalidade = nacionalidade;
            return _pessoaFisica;
        }

        public PessoaFisica ComSexo(Sexo sexo)
        {
            _pessoaFisica.Sexo = sexo;
            return _pessoaFisica;
        }

        public PessoaFisica ComContatos(List<Contato> contatos)
        {
            _pessoaFisica.Contatos = contatos;
            return _pessoaFisica;
        }

        public PessoaFisica ComContato(Contato contato)
        {
            _pessoaFisica.Contatos.Add(contato);
            return _pessoaFisica;
        }

        public PessoaFisica ComEnderecos(List<Endereco> enderecos)
        {
            _pessoaFisica.Enderecos = enderecos;
            return _pessoaFisica;
        }

        public PessoaFisica ComEndereco(Endereco endereco)
        {
            _pessoaFisica.Enderecos.Add(endereco);
            return _pessoaFisica;
        }

        public PessoaFisica Build()
        {
            return _pessoaFisica;
        }
    }
}