using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Commands
{
    public class CreateEmployeeCertificationCommandHandler : IRequestHandler<CreateEmployeeCertificationCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeCertificationCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateEmployeeCertificationCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeCertificationExists = false;
            if (_dbContext.EmployeeCertifications.Count() > 0)
            {
                employeeCertificationExists = _dbContext.EmployeeCertifications.All(u => u.EmployeeId == request.EmployeeId && u.Name == request.Name && u.Institution == request.Institution && u.Active);
            }

            if (employeeCertificationExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="La Certificacion ya existe",
                        Name=""
                    }
                });
            }

            var employeeCertification = new Domain.Entities.EmployeeCertification
            {
                EmployeeId = request.EmployeeId,
                Name = request.Name,
                Institution = request.Institution,
                EmissionDate = request.EmissionDate,
                ProductionDate = request.ProductionDate,
                ExpirationDate = request.ExpirationDate,
            };

            int createResult;
            _dbContext.EmployeeCertifications.Add(employeeCertification);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            var data = new List<string>
            {
                employeeCertification.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
