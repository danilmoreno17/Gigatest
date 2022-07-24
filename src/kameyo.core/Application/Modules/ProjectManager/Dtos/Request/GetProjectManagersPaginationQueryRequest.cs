using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request
{
    public class GetProjectManagersPaginationQueryRequest : IRequest<ResultPaginated<ProjectManagersDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
