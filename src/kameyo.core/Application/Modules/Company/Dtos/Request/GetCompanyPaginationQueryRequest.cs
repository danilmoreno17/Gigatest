using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Company.Dtos.Request
{
    public class GetCompanyPaginationQueryRequest : IRequest<ResultPaginated<CompanyDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
