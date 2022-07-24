using FluentValidation;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Employee.Commands.Validators
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommandRequest>
    {
        public CreateEmployeeCommandValidator()
        {
            //RuleFor(x => x.NumberId)
            //    .Must(x => !EmployeeExits)
            //    .WithMessage(x => $"La empresa ya existe -> {x.NumberId}");

            RuleFor(x => x.Names)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del empleado es requerido.");

        }
    }
}
