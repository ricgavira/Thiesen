namespace Thiesen.Domain.Entities
{
    public class Usuario : BaseEntity<Usuario>
    {
        public Usuario(string nome, string login, string password)
        {
            Nome = nome;
            Login = login;
            Password = password;
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
    }
}
