namespace Thiesen.Domain.Entities
{
    public class Cidade : BaseEntity<Cidade>
    {
        public Cidade(string nome, Estado estado)
        {
            Nome = nome;
            Estado = estado;
        }

        public string Nome { get; private set; }
        public Estado Estado { get; private set; }
    }
}
