using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Identity.User.Dtos.Request
{
    public class DeleteUserCommandRequest:  IRequest<Result<string>>
    {
        public string Id { get; set; } = default!;
    }
}
