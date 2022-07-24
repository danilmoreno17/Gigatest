using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Catalog.Queries
{
    public class GetCatalogsPaginationQueryHandler : IRequestHandler<GetCatalogsPaginationQueryRequest, ResultPaginated<CatalogsDtoResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetCatalogsPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultPaginated<CatalogsDtoResponse>> Handle(GetCatalogsPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = new GetCatalogsPaginationQueryValidator()
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return ResultPaginated<CatalogsDtoResponse>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }

            var catalog = await _context.Catalogs
                .Where(x => x.Active)
                .Select(x => CatalogMapping.MapToCatalogDTO(x))
                .AsNoTracking()
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return catalog;
        }

    }
}
