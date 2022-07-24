using FluentValidation;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Project.Commands.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommandRequest>
    {
        public UpdateProjectCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExists)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
