using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeStudy.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeStudy.Commands
{
    public class DeleteEmployeeStudyCommandHandler : IRequestHandler<DeleteEmployeeStudyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteEmployeeStudyCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteEmployeeStudyCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeStudy = _dbContext.EmployeeStudies.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            employeeStudy.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeStudy.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
