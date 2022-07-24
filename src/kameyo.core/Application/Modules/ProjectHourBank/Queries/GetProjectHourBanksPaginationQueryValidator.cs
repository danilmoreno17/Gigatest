using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Queries
{
    public class GetProjectHourBanksPaginationQueryValidator : AbstractValidator<GetProjectHourBanksPaginationQueryRequest>
    {
        public GetProjectHourBanksPaginationQueryValidator()
        {

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Número de página al menos mayor o igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Tamaño de página al menos mayor o igual a 1.");
        }
    }
}
