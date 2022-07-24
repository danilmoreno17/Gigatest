using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Request;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using Kameyo.Core.Application.Modules.Subsidiary.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.Subsidiary.Queries
{
    public class GetSubsidiaryQueryHandler : IRequestHandler<GetSubsidiaryQueryRequest, Result<SubsidiariesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_NAME = "NAME";
        private readonly string FILTER_FIELD_ID = "ID";
        public GetSubsidiaryQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<SubsidiariesDtoResponse>> Handle(GetSubsidiaryQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var subsidiaries = await _dbContext.Subsidiaries
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => SubsidiaryMapping.MapToSubsidiaryDTO(x))
                .ToListAsync(cancellationToken);
            if (subsidiaries == null) return Result<SubsidiariesDtoResponse>.NotFound();
            return Result<SubsidiariesDtoResponse>.Success(subsidiaries);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.Subsidiary> GetSpecification(GetSubsidiaryQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.Subsidiary> specification = new GetSubsidiariesByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_NAME)
            {
                specification = new GetSubsidiariesByNameSpec(request.Value);
            }
            return specification;
        }
    }
}
