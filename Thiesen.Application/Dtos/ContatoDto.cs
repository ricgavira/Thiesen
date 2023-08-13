﻿using Thiesen.Domain.Enums;

namespace Thiesen.Application.Dtos
{
    public class ContatoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public TipoContato TipoContato { get; set; }
        public int? PessoaFisicaId { get; set; }
        public int? PessoaJuridicaId { get; set; }
    }
}
