using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeAward.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Commands
{
    public class UpdateEmployeeAwardCommandHandler : IRequestHandler<UpdateEmployeeAwardCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateEmployeeAwardCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateEmployeeAwardCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeAward = _dbContext.EmployeeAwards.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            employeeAward.EmployeeId = request.EmployeeId ?? employeeAward.EmployeeId;
            employeeAward.Institution = request.Institution ?? employeeAward.Institution;
            employeeAward.Description = request.Description ?? employeeAward.Description;
            employeeAward.AwardDate = request.AwardDate ?? employeeAward.AwardDate;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeAward.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
