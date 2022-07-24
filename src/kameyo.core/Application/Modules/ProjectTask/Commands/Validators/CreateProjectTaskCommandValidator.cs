using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands.Validators
{
    public class CreateProjectTaskCommandValidator : AbstractValidator<CreateProjectTaskCommandRequest>
    {
        public CreateProjectTaskCommandValidator(/*bool projectTaskExists*/) {
            RuleFor(x => x.Name)
               .Must(x => true/*projectTaskExists*/)
               .WithMessage(x => $"El nombre {x.Name} ya existe.");
        }
    }
}
