using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator(bool userExists)
        {
            RuleFor(x => x.Email)
               .Must(x => !userExists)
               .WithMessage(x => $"El nombre del usario o email ya existe. email -> {x.Email}");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email es requerido.")
                .EmailAddress()
                .WithMessage("Un email valido es requerido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("La contraseña es requerida.");

        }
    }
}
