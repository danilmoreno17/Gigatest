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
    public class GetProjectReportByProjectManagerHandler : IRequestHandler<GetProjectReportByProjectManagerRequest, Result<ProjectReportDtoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectReportByProjectManagerHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectReportDtoResponse>> Handle(GetProjectReportByProjectManagerRequest request, CancellationToken cancellationToken)
        {
            var startDate = new DateTime(request.Year.Value , request.Month.Value, 1);
            var endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month), 23, 59, 59, 999);

            var taskActivities = await _dbContext.ProjectReport
                .Include(x=> x.Project)
                .Include(x => x.Project.ProjectTasks)
                .Where(x=> x.Project.ProjectManagers.Any(x=> x.EmployeeId == request.EmployeeId))
               //.Include(x => x.ProjectManagers)

               //.Where(x => x.ProjectManagers.Any(x => x.EmployeeId == request.EmployeeId))
               .Where(x => x.Project.ProjectTasks.Any(x => x.TaskActivities.Any(x =>  x.EndDate >= startDate && x.EndDate <= endDate)))
               //.Select(x => new ProjectReportGeneratorResponse() { })
               .Select(x => ProjectReportMapping.MapToProjectReportDTO(x))
               .AsNoTracking()
               .ToListAsync();

            if (taskActivities == null) return Result<ProjectReportDtoResponse>.NotFound();
            return Result<ProjectReportDtoResponse>.Success(taskActivities);
      
        }
    }
}
