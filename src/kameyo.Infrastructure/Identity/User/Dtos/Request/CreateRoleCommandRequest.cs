using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class CreateRoleCommandRequest : IRequest<Result<string>>
    {
        public string Name { get; set; }

    }
}
