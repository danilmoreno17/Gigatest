using FluentValidation;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;

namespace Kameyo.Core.Application.Modules.Company.Queries
{
    public class GetCompanyPaginationQueryValidator : AbstractValidator<GetCompanyPaginationQueryRequest>
    {
        public GetCompanyPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Número de página al menos mayor o igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Tamaño de página al menos mayor o igual a 1.");
        }
    }
}
