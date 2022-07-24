using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Contact.Dtos.Request
{
    public class GetContactPaginationQueryRequest : IRequest<ResultPaginated<ContactDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
