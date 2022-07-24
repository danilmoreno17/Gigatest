using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request
{
    public class GetEmployeeAwardQueryRequest : IRequest<Result<EmployeeAwardDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
