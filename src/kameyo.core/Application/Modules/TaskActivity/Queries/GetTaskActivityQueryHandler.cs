using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Kameyo.Core.Application.Modules.TaskActivity.Specifications;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.TaskActivity.Queries
{
    public class GetTaskActivityQueryHandler : IRequestHandler<GetTaskActivityQueryRequest, Result<TaskActivitiesDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly string FILTER_FIELD_PROJECTTASKID = "PROJECTTASKID";
        private readonly string FILTER_FIELD_PROJECTID = "PROJECTID";

        public GetTaskActivityQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<TaskActivitiesDtoResponse>> Handle(GetTaskActivityQueryRequest request, CancellationToken cancellationToken)
        {
            var specification = GetSpecification(request);
            var taskActivities = await _dbContext.TaskActivities
                .AsNoTracking()
                .WithSpecification(specification)
                .Select(x => TaskActivityMapping.MapToTaskActivitiesDTO(x))
                .ToListAsync(cancellationToken);
            if (taskActivities == null) return Result<TaskActivitiesDtoResponse>.NotFound();
            return Result<TaskActivitiesDtoResponse>.Success(taskActivities);
        }

        private ISpecification<Kameyo.Core.Domain.Entities.TaskActivity> GetSpecification(GetTaskActivityQueryRequest request)
        {
            ISpecification<Kameyo.Core.Domain.Entities.TaskActivity> specification = new GetTaskActivitiesByIdSpec(request.Value);
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTTASKID)
            {
                specification = new GetTaskActivitiesByProjectTaskIdSpec(request.Value);
            }
            if (request.Field.ToUpper() == FILTER_FIELD_PROJECTID)
            {
                specification = new GetTaskActivitiesByProjectIdSpec(request.Value);
            }
            return specification;
        }
    }
}
