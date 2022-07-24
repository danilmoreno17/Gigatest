using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request
{
    public class GetProjectHourBanksPaginationQueryRequest : IRequest<ResultPaginated<ProjectHourBanksDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
