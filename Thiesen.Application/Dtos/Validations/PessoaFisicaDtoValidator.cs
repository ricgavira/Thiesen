using FluentValidation;

namespace Thiesen.Application.Dtos.Validations
{
    public class PessoaFisicaDtoValidator : AbstractValidator<PessoaFisicaDto>
    {
        public PessoaFisicaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o Nome!");
        }
    }
}
