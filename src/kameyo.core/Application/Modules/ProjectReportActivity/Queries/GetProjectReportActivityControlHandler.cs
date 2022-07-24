
using Ardalis.Specification;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kameyo.Core.Application.Modules.ProjectReportActivity.Queries
{
    public class GetProjectReportActivityControlHandler : IRequestHandler<ProjectReportActivityControlRequest, Result<ProjectReportActivityControlResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        public GetProjectReportActivityControlHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<ProjectReportActivityControlResponse>> Handle(ProjectReportActivityControlRequest request, CancellationToken cancellationToken)
        {
            var projectActivities = await _dbContext.ProjectReportDetail
                .Include(x=> x.TaskActivity.Employee)
                
                .Where(x => x.ProjectReportId == request.ProjectId)
                //.Select(x => ProjectMapping.MapToProjectDTO(x))
                .Select(x => new ProjectReportActivityControlResponse() { 
                    Id = x.Id, 
                    Description = x.TaskActivity.Description,
                    StartDate = x.TaskActivity.StartDate,
                    EndDate = x.TaskActivity.EndDate,
                    Consultant = string.Format("{0} {1}",x.TaskActivity.Employee.LastName, x.TaskActivity.Employee.Names) ,
                    Observation= x.Observation,

                    IsBillable = x.TaskActivity.IsBillable,
                    Factor = 1,//x.TaskActivity.ProjectTask.Project.ProjectResources.
                    TotalTimeHourApproved = x.TaskActivity.TotalTimeHourApproved,
                    TotaTimeHour = x.TaskActivity.TotalTimeHour}
                )
                 .ToListAsync(); ;



            //project

            if (projectActivities == null) return Result<ProjectReportActivityControlResponse>.NotFound();
            return Result<ProjectReportActivityControlResponse>.Success(projectActivities);
        }
    }
}
