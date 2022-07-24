using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Customer.Dtos.Request
{
    public class GetCustomerPaginationQueryRequest : IRequest<ResultPaginated<CustomerDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
