using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request
{
    public class GetTaskActivityQueryRequest : IRequest<Result<TaskActivitiesDtoResponse>>
    {
        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
