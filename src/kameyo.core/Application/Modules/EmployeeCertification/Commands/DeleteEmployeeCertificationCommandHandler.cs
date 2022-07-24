using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeCertification.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeCertification.Commands
{
    public class DeleteEmployeeCertificationCommandHandler : IRequestHandler<DeleteEmployeeCertificationCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteEmployeeCertificationCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteEmployeeCertificationCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeCertification = _dbContext.EmployeeCertifications.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            employeeCertification.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeCertification.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
