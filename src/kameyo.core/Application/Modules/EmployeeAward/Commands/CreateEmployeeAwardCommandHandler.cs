using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Commands
{
    public class CreateEmployeeAwardCommandHandler : IRequestHandler<CreateEmployeeAwardCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeAwardCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateEmployeeAwardCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeAwardExists = false;
            if (_dbContext.EmployeeAwards.Count() > 0)
            {
                employeeAwardExists = _dbContext.EmployeeAwards.All(u => u.EmployeeId == request.EmployeeId && u.Institution == request.Institution && u.Active);
            }

            if (employeeAwardExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El premio ya existe",
                        Name=""
                    }
                });
            }

            var employeeAward = new Domain.Entities.EmployeeAward 
            {
                EmployeeId = request.EmployeeId,
                Institution = request.Institution,
                Description = request.Description,
                AwardDate = request.AwardDate,
            };

            int createResult;
            _dbContext.EmployeeAwards.Add(employeeAward);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            var data = new List<string>
            {
                employeeAward.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
