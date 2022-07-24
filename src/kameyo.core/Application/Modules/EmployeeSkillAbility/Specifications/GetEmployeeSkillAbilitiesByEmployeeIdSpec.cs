using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Specifications
{
    public class GetEmployeeSkillAbilitiesByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeSkillAbility>
    {
        public GetEmployeeSkillAbilitiesByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
