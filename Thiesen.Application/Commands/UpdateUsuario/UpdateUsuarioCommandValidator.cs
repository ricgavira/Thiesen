using FluentValidation;
using Thiesen.Application.Resources;

namespace Thiesen.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommandValidator : AbstractValidator<UpdateUsuarioCommand>
    {
        public UpdateUsuarioCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredNome);

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredLogin);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.RequiredPassword);
        }
    }
}