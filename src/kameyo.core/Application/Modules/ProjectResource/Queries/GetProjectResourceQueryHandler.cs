using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectResource.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectResource.Queries
{
    public class GetProjectResourceQueryHandler : IRequestHandler<GetProjectResourceQueryRequest, Result<ProjectResourcesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_PROJECTID = "PROJECTID";
        private readonly string FILTER_FIELD_EMPLOYEEID = "EMPLOYEEID";
        public GetProjectResourceQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectResourcesDtoResponse>> Handle(GetProjectResourceQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var projectResources = await _dbContext.ProjectResources
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectResourceMapping.MapToProjectResourceDTO(x))
                .ToListAsync(cancellationToken);
            if (projectResources == null) return Result<ProjectResourcesDtoResponse>.NotFound();
            return Result<ProjectResourcesDtoResponse>.Success(projectResources);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.ProjectResource> GetSpecification(GetProjectResourceQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.ProjectResource> specification = new GetProjectResourcesByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTID)
            {
                specification = new GetProjectResourcesByProjectIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_EMPLOYEEID)
            {
                specification = new GetProjectResourcesByEmployeeIdSpec(request.Value);
            }
            return specification;
        }
    }
}
