using FluentValidation;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Queries
{
    public class GetProjectTasksPaginationQueryValidator : AbstractValidator<GetProjectTasksPaginationQueryRequest>
    {
        public GetProjectTasksPaginationQueryValidator()
        {

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Número de página al menos mayor o igual a 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Tamaño de página al menos mayor o igual a 1.");
        }
    }
}
