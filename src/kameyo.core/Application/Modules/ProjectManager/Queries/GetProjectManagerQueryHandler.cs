using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectManager.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectManager.Queries
{
    public class GetProjectManagerQueryHandler : IRequestHandler<GetProjectManagerQueryRequest, Result<ProjectManagersDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_PROJECTID = "PROJECTID";

        public GetProjectManagerQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectManagersDtoResponse>> Handle(GetProjectManagerQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var projectManagers = await _dbContext.ProjectManagers
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectManagerMapping.MapToProjectManagerDTO(x))
                .ToListAsync(cancellationToken);
            if (projectManagers == null) return Result<ProjectManagersDtoResponse>.NotFound();
            return Result<ProjectManagersDtoResponse>.Success(projectManagers);
        }

        private ISpecification<Kameyo.Core.Domain.Entities.ProjectManager> GetSpecification(GetProjectManagerQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.ProjectManager> specification = new GetProjectManagersByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTID)
            {
                specification = new GetProjectManagersByProjectIdSpec(request.Value);
            }
            return specification;
        }
    }
}
