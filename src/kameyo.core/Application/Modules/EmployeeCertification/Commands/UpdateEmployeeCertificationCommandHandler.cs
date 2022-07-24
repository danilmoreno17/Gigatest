using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Commands
{
    public class UpdateEmployeeCertificationCommandHandler : IRequestHandler<UpdateEmployeeCertificationCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateEmployeeCertificationCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateEmployeeCertificationCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeCertification = _dbContext.EmployeeCertifications.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            employeeCertification.EmployeeId = request.EmployeeId ?? employeeCertification.EmployeeId;
            employeeCertification.Name = request.Name ?? employeeCertification.Name;
            employeeCertification.Institution = request.Institution ?? employeeCertification.Institution;
            employeeCertification.EmissionDate = request.EmissionDate ?? employeeCertification.EmissionDate;
            employeeCertification.ProductionDate = request.ProductionDate ?? employeeCertification.ProductionDate;
            employeeCertification.ExpirationDate = request.ExpirationDate ?? employeeCertification.ExpirationDate; 


            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeCertification.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
