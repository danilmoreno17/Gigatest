using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Commands
{
    public class DeleteEmployeeExperienceCommandHandler : IRequestHandler<DeleteEmployeeExperienceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public DeleteEmployeeExperienceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(DeleteEmployeeExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeExperience = _dbContext.EmployeeExperiences.Where(b => b.Id == request.Id)
                    .FirstOrDefault();

            employeeExperience.Active = false;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeExperience.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
