using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Specifications
{
    public class GetEmployeeSkillAbilityByIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeSkillAbility>
    {
        public GetEmployeeSkillAbilityByIdSpec(string id)
        {
            Query
                .Where(x => x.Id.ToString() == id);
        }
    }
}
