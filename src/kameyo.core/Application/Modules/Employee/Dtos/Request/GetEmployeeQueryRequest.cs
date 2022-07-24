using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Employee.Dtos.Request
{
    public class GetEmployeeQueryRequest : IRequest<Result<EmployeeDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
