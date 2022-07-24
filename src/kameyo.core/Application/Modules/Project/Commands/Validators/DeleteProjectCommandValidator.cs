using FluentValidation;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Project.Commands.Validators
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommandRequest>
    {
        public DeleteProjectCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExits)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
