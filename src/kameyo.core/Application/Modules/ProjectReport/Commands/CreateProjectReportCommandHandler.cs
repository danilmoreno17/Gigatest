using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Kameyo.Core.Domain.Mappings;
using MediatR;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Commands
{
    public class CreateProjectReportCommandHandler : IRequestHandler<CreateProjectReportRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateProjectReportCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Result<string>> Handle(CreateProjectReportRequest request, CancellationToken cancellationToken)
        {
            /*
            var projectReportExists = false;
            if (_dbContext.ProjectResources.Count() > 0)
            {
                projectResourceExists = _dbContext.ProjectResources.All(u => u.EmployeeId == request.EmployeeId && u.ProjectId == request.ProjectId && u.Active);
            }

            if (projectResourceExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El asignacion ya existe",
                        Name=""
                    }
                });
            }
            */


            //TODO Hacer funcionar el CreateSubsidiaryCommandValidator
            /*var validationResult = new CreateSubsidiaryCommandValidator(subsidiaryExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            var startDate = new DateTime(request.Year.Value, request.Month.Value, 1);
            var endDate = new DateTime(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month), 23, 59, 59, 999);

            var projectReport = new Domain.Entities.ProjectReport
            {
                Id = Guid.NewGuid(),
                ProjectId = request.ProjectId,
                CustomerApproved = false,
                Year = request.Year.Value,
                Month = request.Month.Value,
                Invoiced = false,
                State = request.State == null ? 'G' : request.State.Value,
                Paid = false,
                ProjectReportDate = request.ProjectReportDate,
            };

            int createResult;
            _dbContext.ProjectReport.Add(projectReport);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);



            var taskActivities = await _dbContext.TaskActivities

                .Where(x => x.ProjectTask.Project.Id == request.ProjectId)
                .Where(x => x.InProjectReport == false && x.EndDate >= startDate && x.EndDate <= endDate)
                //.Select(x => new ProjectReportGeneratorResponse() { })
                .Select(x => TaskActivityMapping.MapToTaskActivitiesDTO(x))
                .AsNoTracking()
                .ToListAsync();

            foreach (var taskActivity in taskActivities)
            {
                var projectReportDetail = new Domain.Entities.ProjectReportDetail
                {
                    Id = Guid.NewGuid(),
                    ProjectReportId = projectReport.Id,
                    TaskActivityId = taskActivity.Id
                };
                int createResultDetails;
                _dbContext.ProjectReportDetail.Add(projectReportDetail);
                createResultDetails = await _dbContext.SaveChangesAsync(cancellationToken);


                var taskAct = await _dbContext.TaskActivities.FindAsync(taskActivity.Id);
                if (taskAct != null)
                {
                    taskAct.InProjectReport = true;
                    int createResultDetailsTaskActivity;
                    _dbContext.TaskActivities.Update(taskAct);
                    createResultDetailsTaskActivity = await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }


            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                projectReport.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
