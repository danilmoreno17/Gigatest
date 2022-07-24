using FluentValidation;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Employee.Commands.Validators
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommandRequest>
    {
        public UpdateEmployeeCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExists)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
