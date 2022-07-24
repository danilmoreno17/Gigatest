using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Queries
{
    public class GetProjectReportGeneratorHandler : IRequestHandler<ProjectReportGeneratorRequest, Result<ProjectDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectReportGeneratorHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectDtoResponse>> Handle(ProjectReportGeneratorRequest request, CancellationToken cancellationToken)
        {
            var startDate = new DateTime(request.Year, request.Month, 1);
            var endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month), 23, 59, 59, 999);

            var taskActivities = await _dbContext.Projects
                .Include(x => x.ProjectTasks)
                .ThenInclude(x => x.TaskActivities)
                .Where(x => x.ProjectTasks.Any(x => x.Project.CustomerId == request.CustomerId))
                .Where(x => x.ProjectTasks.Any(x => x.TaskActivities.Any(x => x.InProjectReport == false && x.EndDate >= startDate && x.EndDate <= endDate)))
                //.Select(x => new ProjectReportGeneratorResponse() { })
                .Select(x => ProjectMapping.MapToProjectDTO(x))
                .AsNoTracking()
                .ToListAsync();

            if (taskActivities == null) return Result<ProjectDtoResponse>.NotFound();
            return Result<ProjectDtoResponse>.Success(taskActivities);






        }
    }
}
