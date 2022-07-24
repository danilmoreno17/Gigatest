using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommandRequest>
    {
        public DeleteRoleCommandValidator(bool roleExists)
        {
            RuleFor(x => x.Id)
              .Must(x => roleExists)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
