using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Commands
{
    public class CreateEmployeeStudyCommandHandler : IRequestHandler<CreateEmployeeStudyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeStudyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateEmployeeStudyCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeStudyExists = false;
            if (_dbContext.EmployeeStudies.Count() > 0)
            {
                employeeStudyExists = _dbContext.EmployeeStudies.All(u => u.EmployeeId == request.EmployeeId && u.Degree == request.Degree && u.Institution == request.Institution && u.Active);
            }

            if (employeeStudyExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El titulo ya existe",
                        Name=""
                    }
                });
            }

            var employeeStudy = new Domain.Entities.EmployeeStudy
            {
                EmployeeId = request.EmployeeId,
                Institution = request.Institution,
                Degree = request.Degree,
                FieldKnowledge = request.FieldKnowledge,
                EmissionDate = request.EmissionDate,
            };

            int createResult;
            _dbContext.EmployeeStudies.Add(employeeStudy);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            var data = new List<string>
            {
                employeeStudy.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
