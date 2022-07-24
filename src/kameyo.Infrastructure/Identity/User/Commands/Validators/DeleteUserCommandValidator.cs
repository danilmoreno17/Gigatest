using FluentValidation;
using Kameyo.Infrastructure.Identity.User.Dtos.Request;

namespace Kameyo.Infrastructure.Identity.User.Commands.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommandRequest>
    {
        public DeleteUserCommandValidator(bool userExists)
        {
            RuleFor(x => x.Id)
              .Must(x => userExists)
              .WithMessage(x => $"El ID no existe");
        }
    }
}
