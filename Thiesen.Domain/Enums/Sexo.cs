using System.ComponentModel;

namespace Thiesen.Domain.Enums
{
    public enum Sexo
    {
        [Description("Sexo Feminino")]
        Feminino = 0,
        [Description("Sexo Masculino")]
        Masculino = 1,
        [Description("Outras orientações sexuais")]
        Outro = 2
    }
}
