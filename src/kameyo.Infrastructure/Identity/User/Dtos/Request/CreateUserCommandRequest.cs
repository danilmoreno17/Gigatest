using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class CreateUserCommandRequest : IRequest<Result<string>>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Guid? PersonTypeId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;
        public List<UserRolesDto> UserRoles { get; set; } = new List<UserRolesDto>();
        //public Dictionary<string, object> Values { get; set; } = default!;
    }
}
