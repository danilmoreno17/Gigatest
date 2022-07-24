using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommandRequest>
    {
        public UpdateRoleCommandValidator(bool userExists)
        {
            RuleFor(x => x.Id)
               .Must(x => userExists)
               .WithMessage(x => $"El ID no existe");

            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Name != null)
                .WithMessage("El email es requerido.");
        }
    }
}
