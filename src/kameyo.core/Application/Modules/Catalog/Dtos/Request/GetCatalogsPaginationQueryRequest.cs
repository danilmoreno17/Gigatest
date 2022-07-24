using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using MediatR;

namespace Kameyo.Core.Application.Modules.Catalog.Dtos.Request
{
    public class GetCatalogsPaginationQueryRequest : IRequest<ResultPaginated<CatalogsDtoResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
