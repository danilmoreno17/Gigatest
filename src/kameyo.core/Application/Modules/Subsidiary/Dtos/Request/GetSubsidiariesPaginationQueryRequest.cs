using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
public class GetSubsidiariesPaginationQueryRequest : IRequest<ResultPaginated<SubsidiariesDtoResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}