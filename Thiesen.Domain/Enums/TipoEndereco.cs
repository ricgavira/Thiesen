using System.ComponentModel;

namespace Thiesen.Domain.Enums
{
    public enum TipoEndereco
    {
        [Description("Endereço Comercial")]
        Comercial = 0,
        [Description("Endereço Residencial")]
        Residencial = 1
    }
}
