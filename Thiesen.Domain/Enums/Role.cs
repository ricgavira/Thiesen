using System.ComponentModel;

namespace Thiesen.Domain.Enums
{
    public enum Role
    {
        [Description("Administrador")]
        Administrator,
        [Description("Usuario comum")]
        Usuario
    }
}
