using Thiesen.Domain.Enums;

namespace Thiesen.Domain.Entities
{
    public class Contato : BaseEntity<Contato>
    {
        public Contato(string descricao, TipoContato tipoContato, string responsavel)
        {
            Descricao = descricao;
            TipoContato = tipoContato;
            Responsavel = responsavel;
        }

        public string Descricao { get; private set; }
        public string Responsavel { get; private set; }
        public TipoContato TipoContato { get; private set; }
        public int? PessoaFisicaId { get; private set; }
        public int? PessoaJuridicaId { get; private set; }
    }
}
