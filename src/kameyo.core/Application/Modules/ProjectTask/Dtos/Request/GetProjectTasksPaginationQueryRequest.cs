using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request
{
    public class GetProjectTasksPaginationQueryRequest : IRequest<ResultPaginated<ProjectTasksDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
