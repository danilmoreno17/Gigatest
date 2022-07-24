using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Commands
{
    public class CreateEmployeeSkillAbilityCommandHandler : IRequestHandler<CreateEmployeeSkillAbilityCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeSkillAbilityCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<string>> Handle(CreateEmployeeSkillAbilityCommandRequest request, CancellationToken cancellationToken)
        {
            var employeeSkillAbilityExists = false;
            if (_dbContext.EmployeeSkillAbilities.Count() > 0)
            {
                employeeSkillAbilityExists = _dbContext.EmployeeSkillAbilities.All(u => u.EmployeeId == request.EmployeeId && u.Description == request.Description && u.Active);
            }

            if (employeeSkillAbilityExists)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="La Habilidad ya existe",
                        Name=""
                    }
                });
            }

            var employeeSkillAbility = new Domain.Entities.EmployeeSkillAbility
            {
                EmployeeId = request.EmployeeId,
                Description = request.Description,
            };

            int createResult;
            _dbContext.EmployeeSkillAbilities.Add(employeeSkillAbility);
            createResult = await _dbContext.SaveChangesAsync(cancellationToken);

            var data = new List<string>
            {
                employeeSkillAbility.Id.ToString()
            };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
