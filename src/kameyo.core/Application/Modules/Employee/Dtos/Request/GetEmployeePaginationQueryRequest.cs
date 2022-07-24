using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Employee.Dtos.Request
{
    public class GetEmployeePaginationQueryRequest : IRequest<ResultPaginated<EmployeeDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
