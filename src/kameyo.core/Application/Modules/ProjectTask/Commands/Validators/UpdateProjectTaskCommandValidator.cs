using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands.Validators
{
    public class UpdateProjectTaskCommandValidator : AbstractValidator<UpdateProjectTaskCommandRequest>
    {
        public UpdateProjectTaskCommandValidator(/*bool projectTaskExists*/)
        {
            RuleFor(x => x.Id)
               .Must(x => true/*projectTaskExists*/)
               .WithMessage(x => $"El ID no existe");

        }
    }
}
