namespace Thiesen.Domain.Entities
{
    public class Bairro : BaseEntity<Bairro>
    {
        public Bairro(string nome, Cidade cidade)
        {
            Nome = nome;
            Cidade = cidade;
        }

        public string Nome { get; private set; }
        public Cidade Cidade { get; private set; }
    }
}
