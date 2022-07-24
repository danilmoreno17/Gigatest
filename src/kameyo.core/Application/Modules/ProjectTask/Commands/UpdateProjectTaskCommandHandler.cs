using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands
{
    public class UpdateProjectTaskCommandHandler : IRequestHandler<UpdateProjectTaskCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateProjectTaskCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var projectTask = _dbContext.ProjectTasks
                    //.Include(x => x.TaskActivities.Where(z => z.Active))
                    //.Include(x => x.Project)
                    .Where(b => b.Id == request.Id)
                    .FirstOrDefault();

                projectTask.ProjectId = request.ProjectId ?? projectTask.ProjectId;
                projectTask.Name = request.Name ?? projectTask.Name;
                projectTask.Description = request.Description ?? projectTask.Description;
                projectTask.CatalogTaskTypeId = request.CatalogTaskTypeId ?? projectTask.CatalogTaskTypeId;
                projectTask.Order = request.Order ?? projectTask.Order;
                projectTask.StartDate = request.StartDate ?? projectTask.StartDate;
                projectTask.EndDate = request.EndDate ?? projectTask.EndDate;
                projectTask.CloseDate = request.CloseDate ?? projectTask.CloseDate;
                projectTask.DurationHour = request.DurationHour ?? projectTask.DurationHour;
                projectTask.Progress = request.Progress ?? projectTask.Progress;
                projectTask.CatalogTaskStateId = request.CatalogTaskStateId ?? projectTask.CatalogTaskStateId;

                /*
                foreach (var deleteTaskActivity in projectTask.TaskActivities)
                {
                    var deleteTaskActivityExists = request.TaskActivities.Exists(x => x.Id == deleteTaskActivity.Id);
                    if (!deleteTaskActivityExists)
                    {
                        deleteTaskActivity.Active = false;
                    }
                }

                foreach (var taskActivityRequest in request.TaskActivities)
                {
                    var taskActivity = _dbContext.TaskActivities.FirstOrDefault(a => a.Id == taskActivityRequest.Id);
                    if (taskActivity != null)
                    {
                        taskActivity.EmployeId = taskActivityRequest.EmployeeId;
                        taskActivity.Description = taskActivityRequest.Description;
                        taskActivity.StartDate = taskActivityRequest.StartDate;
                        taskActivity.EndDate = taskActivityRequest.EndDate;
                        taskActivity.TotalTimeHour = taskActivityRequest.TotalTimeHour;
                    }
                    else
                    {
                        var taskActivityExists = false;
                        if (_dbContext.TaskActivities.Count() > 0)
                        {
                            taskActivityExists = _dbContext.TaskActivities.All(u => u.ProjectTaskId == taskActivityRequest.ProjectTaskId && u.EmployeId == taskActivityRequest.EmployeeId && u.Description == taskActivityRequest.Description && u.Active);
                        }
                        if (taskActivityExists)
                        {
                            return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                                {
                                    new ResultValidationFailure() {
                                        Code="",
                                        Message="La tarea ya existe",
                                        Name=""
                                    }
                                });
                        }
                        taskActivity = new Domain.Entities.TaskActivity
                        {
                            ProjectTaskId = taskActivityRequest.ProjectTaskId,
                            EmployeId = taskActivityRequest.EmployeeId,
                            Description = taskActivityRequest.Description,
                            StartDate = taskActivityRequest.StartDate,
                            EndDate = taskActivityRequest.EndDate,
                            TotalTimeHour = taskActivityRequest.TotalTimeHour,
                        };
                    }
                    projectTask.TaskActivities.Add(taskActivity);
                }

                */

                

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Result<string>.Success(new List<string> { projectTask.Id.ToString() }, HttpStatusCode.OK);
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
