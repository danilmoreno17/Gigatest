using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Project.Dtos.Request
{
    public class GetProjectPaginationQueryRequest : IRequest<ResultPaginated<ProjectDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
