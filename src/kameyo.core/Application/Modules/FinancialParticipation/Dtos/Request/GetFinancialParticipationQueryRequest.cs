using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Request
{
    public class GetFinancialParticipationQueryRequest : IRequest<Result<FinancialParticipationDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
