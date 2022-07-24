using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectManager.Commands
{
    public class CreateProjectManagerCommandHandler : IRequestHandler<CreateProjectManagerCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateProjectManagerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateProjectManagerCommandRequest request, CancellationToken cancellationToken)
        {
            var projectManagerExists = false;
            if (_dbContext.ProjectManagers.Count() > 0)
            {
                projectManagerExists = _dbContext.ProjectManagers.All(u => u.ProjectId == request.ProjectId && u.EmployeeId == request.EmployeeId && u.Active);
            }

            if (projectManagerExists)
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

            var projectManager = new Domain.Entities.ProjectManager
            {
                ProjectId = request.ProjectId,
                EmployeeId = request.EmployeeId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            int createResult;
            _dbContext.ProjectManagers.Add(projectManager);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);


            var data = new List<string>
            {
                projectManager.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
            //return null;
        }
    }
}
