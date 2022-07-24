using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request
{
    public class DeleteProjectTaskCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
    }
}
