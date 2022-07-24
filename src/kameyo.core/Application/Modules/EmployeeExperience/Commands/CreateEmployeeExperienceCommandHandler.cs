using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Commands
{
    public class CreateEmployeeExperienceCommandHandler : IRequestHandler<CreateEmployeeExperienceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeExperienceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateEmployeeExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeExperienceExists = false;
            if (_dbContext.EmployeeExperiences.Count() > 0)
            {
                employeeExperienceExists = _dbContext.EmployeeExperiences.All(u => u.EmployeeId == request.EmployeeId && u.Title == request.Title && u.CompanyName == request.CompanyName && u.Active);
            }

            if (employeeExperienceExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="La experiencia ya existe",
                        Name=""
                    }
                });
            }

            var employeeExperience = new Domain.Entities.EmployeeExperience
            {
                EmployeeId = request.EmployeeId,
                Title = request.Title,
                CompanyName = request.CompanyName,
                Type = request.Type,
                CompanyCity = request.CompanyCity,
                BeginDate = request.BeginDate,
                FinishDate = request.FinishDate,
                Description = request.Description,
            };

            int createResult;
            _dbContext.EmployeeExperiences.Add(employeeExperience);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            var data = new List<string>
            {
                employeeExperience.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
