﻿using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class Endereco : BaseEntity<Endereco>
    {
        public Endereco(string nome,
                        TipoEndereco tipoEndereco,
                        string cep,
                        int bairroId,
                        string numero)
        {
            Nome = nome;
            TipoEndereco = tipoEndereco;
            Cep = cep;
            BairroId = bairroId;
            Numero = numero;
        }

        public string Nome { get; private set; }
        public int BairroId { get; private set; }
        public Bairro? Bairro { get; private set; }
        public string Numero { get; private set; }
        public string Cep { get; private set; }
        public TipoEndereco TipoEndereco { get; private set; }
        public int PessoaFisicaId { get; private set; }
        public PessoaFisica? PessoaFisica { get; set; }
    }
}