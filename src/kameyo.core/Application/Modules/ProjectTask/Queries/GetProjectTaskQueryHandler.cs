using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectTask.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectTask.Queries
{
    public class GetProjectTaskQueryHandler : IRequestHandler<GetProjectTaskQueryRequest, Result<ProjectTasksDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_PROJECTID = "PROJECTID";
        private readonly string FILTER_FIELD_ID = "ID";
        public GetProjectTaskQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectTasksDtoResponse>> Handle(GetProjectTaskQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var projectTasks = await _dbContext.ProjectTasks
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => ProjectTaskMapping.MapToProjectTasksDTO(x))
                .ToListAsync(cancellationToken);
            if (projectTasks == null) return Result<ProjectTasksDtoResponse>.NotFound();
            return Result<ProjectTasksDtoResponse>.Success(projectTasks);
        }
        private ISpecification<Kameyo.Core.Domain.Entities.ProjectTask> GetSpecification(GetProjectTaskQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.ProjectTask> specification = new GetProjectTasksByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTID)
            {
                specification = new GetProjectTasksByProjectIdSpec(request.Value);
            }
            return specification;
        }
    }
}
