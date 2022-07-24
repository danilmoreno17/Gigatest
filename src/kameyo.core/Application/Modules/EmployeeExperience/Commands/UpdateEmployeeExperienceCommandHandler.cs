using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeExperience.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeExperience.Commands
{
    public class UpdateEmployeeExperienceCommandHandler : IRequestHandler<UpdateEmployeeExperienceCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateEmployeeExperienceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateEmployeeExperienceCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeExperience = _dbContext.EmployeeExperiences.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            employeeExperience.EmployeeId = request.EmployeeId ?? employeeExperience.EmployeeId;
            employeeExperience.Title = request.Title ?? employeeExperience.Title;
            employeeExperience.CompanyName = request.CompanyName ?? employeeExperience.CompanyName;
            employeeExperience.Type = request.Type ?? employeeExperience.Type;
            employeeExperience.CompanyCity = request.CompanyCity ?? employeeExperience.CompanyCity;
            employeeExperience.BeginDate = request.BeginDate ?? employeeExperience.BeginDate;
            employeeExperience.FinishDate = request.FinishDate ?? employeeExperience.FinishDate;
            employeeExperience.Description = request.Description ?? employeeExperience.Description;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeExperience.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
