using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator(bool userExists)
        {
            RuleFor(x => x.Id)
               .Must(x => userExists)
               .WithMessage(x => $"El ID no existe");                       

            RuleFor(x => x.Email)
                .NotEmpty()
                .When(x => x.Email != null)
                .WithMessage("El email es requerido.")
                .EmailAddress()
                .When(x => x.Email != null)
                .WithMessage("Un email valido es requerido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .When(x=> x.Password != null)
                .WithMessage("La contraseña es requerida.");

        }
    }
}
