using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request;
using MediatR;
using System.Net;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Commands
{
    public class UpdateEmployeeSkillAbilityCommandHandler : IRequestHandler<UpdateEmployeeSkillAbilityCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateEmployeeSkillAbilityCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(UpdateEmployeeSkillAbilityCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeSkillAbility = _dbContext.EmployeeSkillAbilities.Where(b => b.Id == request.Id)
                    .FirstOrDefault();


            employeeSkillAbility.EmployeeId = request.EmployeeId ?? employeeSkillAbility.EmployeeId;
            employeeSkillAbility.Description = request.Description ?? employeeSkillAbility.Description;

            int updateResult = await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(new List<string> { employeeSkillAbility.Id.ToString() }, HttpStatusCode.OK);
        }
    }
}
