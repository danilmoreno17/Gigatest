using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class UpdateUserCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? Password { get; set; } = default;
        public Guid? PersonTypeId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;
        public List<UserRolesDto>? UserRoles { get; set; } = null;
    }
}
