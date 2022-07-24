using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class GetUserRolesSelectQueryRequest : IRequest<Result<UserRolesSelectResponse>>
    {
        public Guid UserId { get; set; }
    }
}
