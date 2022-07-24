using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReportActivity.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReportActivity.Commands
{
    public class UpdateProjectActivityCommandHandler : IRequestHandler<UpdateProjectActivityCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectActivityCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Result<string>> Handle(UpdateProjectActivityCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var projectReportDetail = await _dbContext.ProjectReportDetail.FindAsync(request.Id);
                if (projectReportDetail != null)
                {
                    if (request.Observation != null)
                    {
                        projectReportDetail.Observation = request.Observation;
                        int createResultProjectReportDetail;
                        _dbContext.ProjectReportDetail.Update(projectReportDetail);
                        createResultProjectReportDetail = await _dbContext.SaveChangesAsync(cancellationToken);

                    }
                    var taskActivity = await _dbContext.TaskActivities.FindAsync(projectReportDetail.TaskActivityId);

                    if (taskActivity != null)
                    {
                        if (request.TotalTimeHourApproved != null)
                            taskActivity.TotalTimeHourApproved = request.TotalTimeHourApproved.Value;
                        if (request.IsBillable != null)
                            taskActivity.IsBillable = request.IsBillable.Value;
                        taskActivity.CalculateFactor = 1;
                      
                        int createResultTaskActivity;
                        _dbContext.TaskActivities.Update(taskActivity);
                        createResultTaskActivity = await _dbContext.SaveChangesAsync(cancellationToken);
                    }
                }

                return Result<string>.Success(new List<string> { projectReportDetail.Id.ToString() }, HttpStatusCode.OK);
                /*
                var taskAct = await _dbContext.TaskActivities.FindAsync(taskActivity.Id);
                if (taskAct != null)
                {
                    taskAct.InProjectReport = true;
                    int createResultDetailsTaskActivity;
                    _dbContext.TaskActivities.Update(taskAct);
                    createResultDetailsTaskActivity = await _dbContext.SaveChangesAsync(cancellationToken);
                }
                */

            }
            catch (Exception ex)
            {
                var errors = new List<ResultValidationFailure>()
                    {new () {Message = "Se genero una exception"}};
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}
