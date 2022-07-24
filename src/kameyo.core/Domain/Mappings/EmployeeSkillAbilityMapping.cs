using Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class EmployeeSkillAbilityMapping
    {
        public EmployeeSkillAbilityMapping()
        { 
        }

        public static EmployeeSkillAbilitiesDtoResponse MapToEmployeeSkillAbilityDTO(Domain.Entities.EmployeeSkillAbility entity)
        {
            return new EmployeeSkillAbilitiesDtoResponse
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Description = entity.Description,
            };
        }
    }
}
