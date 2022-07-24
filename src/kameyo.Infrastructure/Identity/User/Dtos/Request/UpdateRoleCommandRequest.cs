using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class UpdateRoleCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
