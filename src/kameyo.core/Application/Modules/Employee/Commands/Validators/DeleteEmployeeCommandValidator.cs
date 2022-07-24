using FluentValidation;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Employee.Commands.Validators
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommandRequest>
    {
        public DeleteEmployeeCommandValidator()
        {
            //RuleFor(x => x.Id)
            //    .Must(x => companyExits)
            //    .WithMessage(x => $"El ID no existe");
        }
    }
}
