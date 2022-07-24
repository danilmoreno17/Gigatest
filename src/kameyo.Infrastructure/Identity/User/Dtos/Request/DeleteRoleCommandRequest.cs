using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class DeleteRoleCommandRequest : IRequest<Result<string>>
    {
        public string Id { get; set; }
    }
}
