using FluentValidation;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Employee.Queries
{
    public class GetEmployeePaginationQueryValidator : AbstractValidator<GetEmployeePaginationQueryRequest>
    {
        public GetEmployeePaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Número de página al menos mayor o igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Tamaño de página al menos mayor o igual a 1.");
        }
    }
}
