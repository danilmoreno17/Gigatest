using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleCommandValidator(bool roleExists)
        {
            RuleFor(x => x.Name)
               .Must(x => !roleExists)
               .WithMessage(x => $"El nombre del rol ya existe. email -> {x.Name}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El rol es requerido.");
        }
    }
}