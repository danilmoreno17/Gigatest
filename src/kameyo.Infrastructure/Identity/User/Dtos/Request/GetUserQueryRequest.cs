using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class GetUserQueryRequest : IRequest<Result<UsersResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

    }
}
