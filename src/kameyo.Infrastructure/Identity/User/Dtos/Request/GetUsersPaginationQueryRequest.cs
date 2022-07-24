using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class GetUsersPaginationQueryRequest : IRequest<ResultPaginated<UsersResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
