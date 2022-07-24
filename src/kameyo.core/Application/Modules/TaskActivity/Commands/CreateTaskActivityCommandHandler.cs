using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.TaskActivity.Commands
{
    public class CreateTaskActivityCommandHandler : IRequestHandler<CreateTaskActivityCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateTaskActivityCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateTaskActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var TaskActivityExists = false;
            if (_dbContext.TaskActivities.Count() > 0)
            {
                TaskActivityExists = _dbContext.TaskActivities.All(u => u.ProjectTaskId == request.ProjectTaskId && u.EmployeeId == request.EmployeeId && u.Description == request.Description && u.Active);
            }

            if (TaskActivityExists)
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
            //TODO Hacer funcionar el CreateSubsidiaryCommandValidator
            /*var validationResult = new CreateSubsidiaryCommandValidator(subsidiaryExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/
            var projectTask = await _dbContext.ProjectTasks
                .Include(x => x.Project)
                .ThenInclude(x => x.ProjectResources)
                .Where(x => x.Id == request.ProjectTaskId && x.Active).FirstOrDefaultAsync();

            if (projectTask == null) return Result<string>.NotFound();

            var project = _dbContext.Projects
                .Where(x => x.Id == projectTask.ProjectId && x.Active)
                .FirstOrDefault();

            if (project == null) return Result<string>.NotFound();


            var taskActivity = new Domain.Entities.TaskActivity
            {
                ProjectTaskId = request.ProjectTaskId,
                CalculateFactor = projectTask == null ? 1 : projectTask.Project.CostHourMenProject,
                EmployeeId = request.EmployeeId,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalTimeHour = request.TotalTimeHour,
                TotalTimeHourApproved = request.TotalTimeHour,
                IsBillable = request.IsBillable,
            };

            int createResult;
            _dbContext.TaskActivities.Add(taskActivity);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                taskActivity.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
