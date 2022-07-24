using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using Kameyo.Core.Application.Modules.Catalog.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Catalog.Queries
{
    public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQueryRequest, Result<CatalogsDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_PARENTID = "PARENTID";

        public GetCatalogQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<CatalogsDtoResponse>> Handle(GetCatalogQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var catalogs = await _dbContext.Catalogs
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => CatalogMapping.MapToCatalogDTO(x))
                .ToListAsync(cancellationToken);
            if (catalogs == null) return Result<CatalogsDtoResponse>.NotFound();
            return Result<CatalogsDtoResponse>.Success(catalogs);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.Catalog> GetSpecification(GetCatalogQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.Catalog> specification = new GetCatalogsByIdSpecs(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetCatalogsByNameSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PARENTID)
            {
                specification = new GetCatalogsByParentIdSpecs(request.Value);
            }
            return specification;
        }
    }
}
