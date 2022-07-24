using Kameyo.Core.Application.Common.Models;
using Kameyo.Infrastructure.Identity.User.Dtos.Response;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class UpdateUserRolesSelectCommandRequest : IRequest<Result<string>>
    {
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
        public bool RoleSelected { get; set; }

    }
}