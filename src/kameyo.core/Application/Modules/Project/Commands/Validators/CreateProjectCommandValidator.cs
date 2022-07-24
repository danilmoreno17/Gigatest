using FluentValidation;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Project.Commands.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommandRequest>
    {
        public CreateProjectCommandValidator()
        {
            //RuleFor(x => x.NumberId)
            //    .Must(x => !ProjectExits)
            //    .WithMessage(x => $"La empresa ya existe -> {x.NumberId}");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del Projecto es requerido.");

        }
    }
}
