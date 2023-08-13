using System.ComponentModel;

namespace Thiesen.Domain.Enums
{
    public enum TipoContato
    {
        [Description("Telefone")]
        Telefone = 0,
        [Description("Celular")]
        Celular = 1,
        [Description("E-Mail")]
        Email = 2
    }
}
