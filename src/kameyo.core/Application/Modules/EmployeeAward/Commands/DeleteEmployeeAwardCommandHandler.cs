using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Commands
{
    public class DeleteEmployeeAwardCommandHandler : IRequestHandler<DeleteEmployeeAwardCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteEmployeeAwardCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteEmployeeAwardCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeAward = _dbContext.EmployeeAwards.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            employeeAward.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeAward.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
