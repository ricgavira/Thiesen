using FluentValidation;
using Thiesen.Application.Helpers;
using Thiesen.Application.Resources;

namespace Thiesen.Application.Commands.CreatePessoaFisica
{
    public class CreatePessoaFisicaCommandValidator : AbstractValidator<CreatePessoaFisicaCommand>
    {
        public CreatePessoaFisicaCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredNome);

            RuleFor(x => x.NomeDaMae)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredNomeMae);

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .WithMessage(ValidationMessages.RequiredDataNascimento)
                .LessThan(DateTime.Now)
                .WithMessage(ValidationMessages.InvalidDataNascimento);

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredCPF)
                .Must(CPFHelper.IsValid)
                .WithMessage(ValidationMessages.InvalidCPF);
        }
    }
}