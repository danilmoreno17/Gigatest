using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectTask.Commands
{
    public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateProjectTaskCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateProjectTaskCommandRequest request, CancellationToken cancellationToken)
        {
            var projectTaskExists = false;
            if (_dbContext.ProjectTasks.Count() > 0) 
            {
                projectTaskExists = _dbContext.ProjectTasks.All(u => u.Name == request.Name && u.Active);
            }

            if (projectTaskExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El nombre ya existe",
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

            var projectTask = new Domain.Entities.ProjectTask
            {
                ProjectId = request.ProjectId,
                Name = request.Name,
                Description = request.Description,
                CatalogTaskTypeId = request.CatalogTaskTypeId,
                Order = request.Order,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CloseDate = request.CloseDate,
                DurationHour = request.DurationHour,
                Progress = request.Progress,
                CatalogTaskStateId = request.CatalogTaskStateId,
            };

            int createResult;
            _dbContext.ProjectTasks.Add(projectTask);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);


            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                projectTask.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
