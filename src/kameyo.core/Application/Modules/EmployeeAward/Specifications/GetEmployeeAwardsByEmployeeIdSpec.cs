using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.EmployeeAward.Specifications
{
    public class GetEmployeeAwardsByEmployeeIdSpec : Specification<Kameyo.Core.Domain.Entities.EmployeeAward>
    {
        public GetEmployeeAwardsByEmployeeIdSpec(string employeeId)
        {
            Query
                .Where(x => x.EmployeeId.ToString() == employeeId);
        }
    }
}
