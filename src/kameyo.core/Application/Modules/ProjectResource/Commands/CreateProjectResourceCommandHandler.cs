using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.ProjectResource.Commands
{
    public class CreateProjectResourceCommandHandler : IRequestHandler<CreateProjectResourceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateProjectResourceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateProjectResourceCommandRequest request, CancellationToken cancellationToken)
        {
            var projectResourceExists = false;
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


            //TODO Hacer funcionar el CreateSubsidiaryCommandValidator
            /*var validationResult = new CreateSubsidiaryCommandValidator(subsidiaryExists)
                .Validate(request);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/

            var projectResource = new Domain.Entities.ProjectResource
            {
                ProjectId = request.ProjectId,
                EmployeeId = request.EmployeeId,
                CatalogEmployeeRolId = request.CatalogEmployeeRolId,
                CalculateFactorEmployee = request.CalculateFactorEmployee,
                CalculateFactorProject = request.CalculateFactorProject,
            };

            int createResult;
            _dbContext.ProjectResources.Add(projectResource);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);


            /*if (createResult<=0)
            {
                return Result<string>.PreconditionFailure(.Errors.MapToResultValidationFailure());
            }*/

            var data = new List<string>
            {
                projectResource.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
